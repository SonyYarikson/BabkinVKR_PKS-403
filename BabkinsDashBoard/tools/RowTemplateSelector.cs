using Models;
using System.Windows;
using System.Windows.Controls;

namespace BabkinsDashBoard.tools

{
    public class RowTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate ImageTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Row row)
            {
                // В этом примере предполагается, что у вашего класса Row есть свойство RowType,
                // которое указывает тип контента (например, "text" или "picture").
                switch (row.RowType)
                {
                    case "text":
                        return TextTemplate;
                    case "picture":
                        return ImageTemplate;
                    default:
                        // Возвращаем шаблон по умолчанию или бросаем исключение, если требуется.
                        return base.SelectTemplate(item, container);
                }
            }

            // Возвращаем шаблон по умолчанию или бросаем исключение, если требуется.
            return base.SelectTemplate(item, container);
        }
    }
}