using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WcfRestService.App_Code;
namespace WcfRestService
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class Bussines_Layer
    {
        #region "SampleItem"
        
        // TODO: Implement the collection resource that will contain the SampleItem instances

        [WebGet(UriTemplate = "SampleItem")]
        public List<SampleItem> GetCollection()
        {
            // TODO: Replace the current implementation to return a collection of SampleItem instances
           return Database.Items.Values.ToList();
            //return new List<SampleItem>() { new SampleItem() { Id = 1, StringValue = "Hello" } };
        }

        [WebInvoke(UriTemplate = "SampleItem", Method = "POST")]
        public SampleItem Create(SampleItem instance)
        {
            // TODO: Add the new instance of SampleItem to the collection
            Database.Items.Add(instance.Id, instance);
            return Database.Items[instance.Id];
           // throw new NotImplementedException();
        }

        [WebGet(UriTemplate = "SampleItem?id={id}")]
        public SampleItem Get(int id)
        {
            // TODO: Return the instance of SampleItem with the given id
            return Database.Items[id];
           // throw new NotImplementedException();
        }

        [WebInvoke(UriTemplate = "SampleItem?id={id}", Method = "PUT")]
        public SampleItem Update(int id, SampleItem instance)
        {
            // TODO: Update the given instance of SampleItem in the collection
            SampleItem item;
            if (Database.Items.TryGetValue(id, out item))
            {
                item.StringValue = instance.StringValue;
            }
            return instance;
            //throw new NotImplementedException();
        }

        [WebInvoke(UriTemplate = "SampleItem?id={id}", Method = "DELETE")]
        public void Delete(int id)
        {
            // TODO: Remove the instance of SampleItem with the given id from the collection
            // Remove the instance of SampleItem with the given id from the collection
            SampleItem item;
            if (Database.Items.TryGetValue(id, out item))
            {
                Database.Items.Remove(id);
            }
            //throw new NotImplementedException();
        }
        #endregion

    }
}
