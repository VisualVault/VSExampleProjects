using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VisualVault.Examples.AdvancedSearch.DataAccess
{
    public class BoundFieldEx : BoundField
    {
        protected override object GetValue(Control controlContainer)
        {
            object data = null;
            string boundField = DataField;

            if (controlContainer == null)
            {
                throw new HttpException("DataControlField_NoContainer");
            }

            // Get the DataItem from the container
            object dataItem = DataBinder.GetDataItem(controlContainer);

            if (dataItem == null && !DesignMode)
            {
                throw new HttpException("DataItem_Not_Found");
            }

            // Get value of field in data item.
            if (!boundField.Equals(ThisExpression) && dataItem != null)
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataItem);
                string propertyName = boundField;

                // Store current object here as we'll be traversing object graph.
                object currObject = dataItem;                   

                string[] propPath = propertyName.Split('.');
                PropertyDescriptor property = null;

                // We're going to access the object graph from the root (dataItem)
                // property by property as specified in the BoundField.
                for (int i = 0; i < propPath.Length; ++i)
                {
                    string currProp = propPath[i];
                    property = properties.Find(currProp, false);

                    if (property == null)
                        throw new HttpException("Could not find property or subproperty " + currProp);

                    if (i < propPath.Length - 1)
                    {
                        object newCurrObject = property.GetValue(currObject);
                        
                        if (newCurrObject == null)
                        {
                            // Make binding silently fail to be consistent with ASP.NET databinding.
                            currObject = null;
                            break;
                        }
                        currObject = newCurrObject;
                        properties = TypeDescriptor.GetProperties(currObject);
                    }
                }

                if (property != null) data = currObject != null ? property.GetValue(currObject) : null;
            }
            else
            {
                // dataItem is null or we are binding against the data source itself
                data = DesignMode ? GetDesignTimeValue() : dataItem;
            }

            return data;
        }
    }
}