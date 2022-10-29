using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiDNSForDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoclDNSController : ControllerBase
    {
        [HttpPost ("IsCangeDNS")]
        public  IActionResult IsCangeDNS( DNSRequest dNS  )
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();

                if (myContext.LockDNs.Any(x => x.HostName == dNS.Mack && x.DNS == dNS.DNS))
                {
                    return   Ok(true);
                }
                else
                {
                    return Ok(false);
                }    
            }
            catch (Exception ex)
            {
                return NotFound ("ошибка  БД");
            }

        }

        [HttpPost("IsAddDNS")]
        public  IActionResult  IsAddDNS(DNSRequest dNS)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
               
                if (myContext.LockDNs.Any(x=>x.HostName == dNS.Mack ))
                {
                    return Ok( true);
                }
                else
                {
                      return Ok(false);
                }
            }
            catch (Exception ex)
            {
                return NotFound("ошибка  БД");
            }
        }


        [HttpPost("AddDns")]
        public ActionResult AddDns ( DNSRequest  dNS)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                    myContext.LockDNs.Add(new DB.LockDNS
                    {
                        DNS = dNS.DNS,
                        HostName = dNS.Mack,
                        TimeAut = 5
                    });
                    myContext.SaveChanges();
                    return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("ошибка  БД");
            }
        }


        [HttpPost("GetNewDNS")]
        public ActionResult<string> GetNewDNS (DNSRequest dNS)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                var r = myContext.LockDNs.Single(x => x.HostName == dNS.Mack);
                return Ok(r.DNS);
            }
            catch (Exception ex)
            {
                return NotFound("ошибка  БД");
            }
        }
    }
}
