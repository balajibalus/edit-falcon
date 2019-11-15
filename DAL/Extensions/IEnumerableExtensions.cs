using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Extensions
{
   public static class IEnumerableExtensions
    {

        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        {
            
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())

                   };
        }
        public static IEnumerable<SelectListItem> ToSelectListItemString<T>(this IEnumerable<T> items, int selectedValue)
        {

            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())

                   };
        }
        public static IEnumerable<SelectListItem> ToSelectListItemGender<T>(this IEnumerable<T> items, int selectedValue)
        {

            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())

                   };
        }

        public static IEnumerable<SelectListItem> ToSelectListItemStatus<T>(this IEnumerable<T> items, int selectedValue)
        {

            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())

                   };
        }
        public static IEnumerable<SelectListItem> ToSelectListItemColor<T>(this IEnumerable<T> items, int selectedValue)
        {

            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())

                   };
        }

        public static IEnumerable<SelectListItem> ToSelectListItemSeason<T>(this IEnumerable<T> items, int selectedValue)
        {

            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())

                   };
        }
        public static IEnumerable<SelectListItem> ToSelectListItemDisease<T>(this IEnumerable<T> items, int selectedValue)
        {

            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())

                   };
        }

    }
}
