using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp_Megapolis_test.Models;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace MvcApp_Megapolis_test.Controllers
{
    public class HomeController : Controller
    {

             
        public ActionResult Index()
        {         
            return View();
        }              

        public JsonResult DataHandler(DTParameters param)
        {
            try
            {
                var dtsource = new List<Transport>();
                using (SystenProjectEntities dc = new SystenProjectEntities())
                {
                    dtsource = dc.Transport.ToList();
                }

                List<String> columnSearch = new List<string>();

                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }
                
                List<Transport> data = new ResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, dtsource, columnSearch);
                int count = new ResultSet().Count(param.Search.Value, dtsource, columnSearch);
                                           
                DTResult<Transport> result = new DTResult<Transport>
                {
                    draw = param.Draw,
                    data = data,
                    recordsFiltered = count,
                    recordsTotal = count
                };
                return Json(result);
               
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
                
        public ActionResult ActionRecord(int id_ ,string rout_ , string timeDep_ , string timeArr_ , string stop_ ,string action)
        {
            try
            {
                using (SystenProjectEntities dc = new SystenProjectEntities())
                {
                    switch (action)
                    {
                        case "del":
                            var del = dc.Transport.Find(id_);

                            if (del == null)
                                return HttpNotFound();

                            dc.Transport.Remove(del);
                            dc.SaveChanges();
                            break;
                        case "add":
                            dc.Transport.Add(
                                 new Transport{
                                     rout = rout_,
                                     timeDep = timeDep_,
                                     timeArr = timeArr_,
                                     stop = stop_,
                                 });
                            dc.SaveChanges();
                            break;
                        case "update":                           
                            var update = dc.Transport.Find(id_);
                            update.rout = rout_;
                            update.timeDep = timeDep_;
                            update.timeArr = timeArr_;
                            update.stop = stop_;
                            dc.SaveChanges();
                            break;
                        default:
                            break;
                    }
                }

                return View("Index");            
            }catch(Exception ex)
            {
                return Json(new { error = ex.Message });            
            }            
        }       
    }
}
