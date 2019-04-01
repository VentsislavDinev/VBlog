using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBlog.Data.EntityFramework.Migrations.SeedData
{

    //public class DefaultSettingsCreator
    //{
    //    private readonly EducationDbContext _context;

    //    public DefaultSettingsCreator(EducationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public void Create()
    //    {
    //        //Emailing
    //        AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "admin@mydomain.com");
    //        AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "mydomain.com mailer");

    //        //Languages
    //        AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "en");
    //    }

    //    private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
    //    {
    //        if (_context.Settings.Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
    //        {
    //            return;
    //        }

    //        _context.Settings.Add(new Setting(tenantId, null, name, value));
    //        _context.SaveChanges();
    //    }
    //}
}
