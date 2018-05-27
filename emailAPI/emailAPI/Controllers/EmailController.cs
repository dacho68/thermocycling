using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using System.Web;
using System.Net.Mail;

namespace emailAPI.Controllers
{
  public class EmailController : ApiController
  {
    // GET api/<controller>
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
      return "value";
    }

  

    public void Post([FromBody]string[] values)
    {
      MailMessage msg = new MailMessage();

      msg.From = new System.Net.Mail.MailAddress(values[1], values[0]);
      msg.To.Add(new System.Net.Mail.MailAddress("dacho68@gmail.com", "Dac 68"));

      msg.Subject = "Customer questions";
      msg.Body = values[2];

      SmtpClient client = new SmtpClient("in-v3.mailjet.com", 587);
      client.DeliveryMethod = SmtpDeliveryMethod.Network;
      client.EnableSsl = true;
      client.UseDefaultCredentials = false;
      client.Credentials = new System.Net.NetworkCredential("ca99579f2f22919d28f00bcbbd1fe62f", "391368c841b30f01283a1b293772ee17");

      client.Send(msg);

      MailMessage msgJoel = new MailMessage();

      msgJoel.From = new System.Net.Mail.MailAddress(values[1], values[0]);
      msgJoel.To.Add(new System.Net.Mail.MailAddress("Joel.Delisle.com", "Joel Delisle"));

      msgJoel.Subject = "Customer questions";
      msgJoel.Body = values[2];

 
      client.Send(msgJoel);
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
    }
  }
}