using WebAppCoreDemo.Data;
using System.Collections.Generic;

namespace WebAppCoreDemo.Models.Repositories
{
    public class OptionalValues
    {
        public IEnumerable<SelectOptions> GetProductStatuses
        {
            get{
                using(var db = new DbDemoContext())
                {
                    var rows = db.Status;
                    foreach(var status in rows){
                        yield return new SelectOptions
                        {
                            Value = status.Id,
                            Text = status.Name
                        };
                    }
                }
            }
        }
    }
}