//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace VBlog.Web.Common.Helpers
//{
//    public static class DropdownDayMountAndYear
//    {
//        public static string DatePickerDropDowns(this HtmlHelper helper,
//            string dayName, string monthName, string yearName)
//        {
//            TagBuilder daysList = new TagBuilder("select");
//            TagBuilder monthsList = new TagBuilder("select");
//            TagBuilder yearsList = new TagBuilder("select");

//            daysList.Attributes.Add("name", dayName);
//            monthsList.Attributes.Add("name", monthName);
//            yearsList.Attributes.Add("name", yearName);

//            StringBuilder days = new StringBuilder();
//            StringBuilder months = new StringBuilder();
//            StringBuilder years = new StringBuilder();

//            int beginYear = DateTime.UtcNow.Year - 100;
//            int endYear = DateTime.UtcNow.Year;

//            for (int i = 1; i <= 31; i++)
//            {
//                days.AppendFormat("<option value='{0}'>{0}</option>", i);
//            }

//            for (int i = 1; i <= 12; i++)
//            {
//                months.AppendFormat("<option value='{0}'>{0}</option>", i);
//            }

//            for (int i = beginYear; i <= endYear; i++)
//            {
//                years.AppendFormat("<option value='{0}'>{0}</option>", i);
//            }
//            daysList.InnerHtml = days.ToString();
//            monthsList.InnerHtml = months.ToString();
//            yearsList.InnerHtml = years.ToString();

//            return string.Concat(daysList.ToString(), monthsList.ToString(), yearsList.ToString());
//        }
//    }
//}