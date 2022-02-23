using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadViagem.Extensions
{
    public static class Extension
    {
        public static SelectList ToSelectList<T>(this IEnumerable<T> collection,
                             string dataValueField, string dataTextField)
        {
            return new SelectList(collection, dataValueField, dataTextField);
        }

        public static SelectList AddDefaultOption(this SelectList list,
            string dataTextField = "Selecione", string selectedValue = "0", bool selected = false)
        {
            var items = new List<SelectListItem>
                            {
                                new SelectListItem {Text = dataTextField, Value = selectedValue, Selected = selected}
                            };

            items.AddRange(list);
            return new SelectList(items, "Value", "Text", selected ? selectedValue : list.SelectedValue);
        }
    }
}
