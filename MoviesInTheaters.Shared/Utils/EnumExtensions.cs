using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace MoviesInTheaters.Shared.Utils
{
    public static class EnumExtensions
    {
        public static List<SelectListItem> PrepareSelectTag<T>(bool addNull = false) where T : Enum
        {
            var models = new List<SelectListItem>();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString() == "NULL" && !addNull)
                    continue;
                models.Add(new SelectListItem
                {
                    Text = item.GetDisplayDescription().ToUpper(),
                    Value = item.ToString()
                });
            }

            return models.OrderBy(_ => _.Text).ToList();
        }
        public static string GetDisplayDescription(this Enum enumValue)
        {
            if (enumValue != null)
                return enumValue.GetType().GetMember(enumValue.ToString())
                    .FirstOrDefault()?
                    .GetCustomAttribute<DisplayAttribute>()
                    ?.GetDescription() ?? enumValue.ToString();
            return string.Empty;
        }
    }
}
