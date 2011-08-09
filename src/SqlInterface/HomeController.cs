using System;
using System.Linq;
using System.Web.Mvc;
using AFPSTDomainCore.Repositories.impl;
using AFPSTDomainCore.Services.impl;

namespace ErrorQueueMonitor.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
//        readonly string[] _list = {
//                                "AFP-EdiDocumentsIn", "AFP-EdiDocumentsOut", "EDI Invoice Service",
//                                "Email Service", "MassTransit.RuntimeServices",
//                                "Process FedEx Shipments", "Process LabelPrintRequestMessage",
//                                "Process OrderRequestReceivedMessages", "Process ShipRequestMessages",
//                                "Set Shipped List"
//                            };
 
        public ActionResult Index(string queueName)
        {
            var qRepo = new MSMQRepository();
            try
            {
                ViewData["errorQueues"] = qRepo.FindWhere("automation2", q => q.QueueName.EndsWith("error") && q.GetAllMessages().Count() > 0);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.ToString();
            }
            var ss = new ServicesService();
            try
            {
                ViewData["servicelist"] = ss.GetServicesOn("automation2").Where(s => s.Name.StartsWith("AFP"));
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] += ex.ToString();
            }
            return View();

        }

//        private bool we_want_to_see(Service service)
//        {
//            return _list.Contains(service.Name);
//        }
    }
}
