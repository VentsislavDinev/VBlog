using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Threading.Timers;
using Abp.Timing;
using System;
using VBlog.Infrastructure.Core.Users;
using Abp.Threading.BackgroundWorkers;

namespace VBlog.Service.Users
{

    /// <summary>
    /// A sample background worker to make a user passive if he/she did not login in last 30 days.
    /// </summary>
    public class MakeInactiveUsersPassiveWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        /// <summary>
        /// The _user repository.
        /// </summary>
        private readonly IRepository<User, long> _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MakeInactiveUsersPassiveWorker"/> class.
        /// </summary>
        /// <param name="timer">
        /// The timer.
        /// </param>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        public MakeInactiveUsersPassiveWorker(AbpTimer timer, IRepository<User, long> userRepository)
            : base(timer)
        {
            _userRepository = userRepository;
            Timer.Period = 5000; //5 seconds (good for tests, but normally will be more)
        }

        /// <summary>
        /// The do work.
        /// </summary>
        [UnitOfWork]
        protected override void DoWork()
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var oneMonthAgo = Clock.Now.Subtract(TimeSpan.FromDays(30));

                var inactiveUsers = _userRepository.GetAllList(u =>
                    u.IsActive &&
                    ((u.LastModificationTime < oneMonthAgo && u.LastModificationTime != null) || (u.CreationTime < oneMonthAgo && u.LastModificationTime == null))
                );

                foreach (var inactiveUser in inactiveUsers)
                {
                    inactiveUser.IsActive = false;
                    Logger.Info(inactiveUser + " made passive since he/she did not login in last 30 days.");
                }

                CurrentUnitOfWork.SaveChanges();
            }
        }
    }
}
