using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Security.Policy;
using System.Security;
using System.Text;

/// <summary>
/// Summary description for emailAndSms
/// </summary>
public class emailAndSms
{

    public string BroadcastSMS(string mobileNo, string SMSMode, string txtMsg)
    {
        string userId = "comag-ts";
        string authCode = "7051494";
        string RevertText = "-- Invalid mobile number --";
        try
        {
            if (mobileNo.Length >= 10)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://mkisan.gov.in/ksewa/ksewa.aspx");
                request.Timeout = 900000; request.ReadWriteTimeout = 900000;
                request.ProtocolVersion = HttpVersion.Version10; request.UserAgent = ".NET Framework Example Client";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows98; DigExt)";
                request.Method = "POST"; String query = "" + "txtMsg=" + System.Uri.EscapeDataString(txtMsg) + "&mobileNo=" +
                                System.Uri.EscapeDataString(mobileNo) + "&SMSMode=" +
                                System.Uri.EscapeDataString(SMSMode) + "&userId=" +
                                System.Uri.EscapeDataString(userId) + "&authCode=" +
                                System.Uri.EscapeDataString(authCode);
                byte[] byteArray = Encoding.ASCII.GetBytes(query); request.ContentType = "application/x-www-form-urlencoded"; request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length); dataStream.Close();
                WebResponse response = request.GetResponse();
                String Status = ((HttpWebResponse)response).StatusDescription;
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                RevertText = responseFromServer;
            }
            else
            {
                RevertText = "-- Invalid mobile number --";
            }
        }
        catch (Exception ex)
        {
            RevertText = ex.ToString();
        }
        return RevertText;
    }



    public string sendSms(string mobileNo, string message)
    {
        string username = "rythuts.sms";
        string pin = "3mvng5gk";
        string senderId = "TSGOVT";

        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptAllCertifications);
        string s = "https://smsgw.sms.gov.in/failsafe/HttpLink?username=" + username + "&pin=" + pin + "&message=" + message + "&mnumber=91" + mobileNo.Trim() + "&signature=" + senderId + "";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://smsgw.sms.gov.in/failsafe/HttpLink?username=" + username + "&pin=" + pin + "&message=" + message + "&mnumber=91" + mobileNo.Trim() + "&signature=" + senderId + "");
        
        request.Method = "POST";
        HttpWebResponse hwresponse = (HttpWebResponse)request.GetResponse();
        string ver = hwresponse.ProtocolVersion.ToString();
        StreamReader reader = new StreamReader(hwresponse.GetResponseStream());

        return s;
    }
    public bool AcceptAllCertifications(object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) == SslPolicyErrors.RemoteCertificateChainErrors))
        {
            return false;
        }
        else if (((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) == SslPolicyErrors.RemoteCertificateNameMismatch))
        {
            Zone z = default(Zone);
            z = Zone.CreateFromUrl(((HttpWebRequest)sender).RequestUri.ToString());
            if ((z.SecurityZone == System.Security.SecurityZone.Intranet | z.SecurityZone == System.Security.SecurityZone.MyComputer))
            {
                return true;
            }
            return true;
        }
        else
        {
            return true;
        }
        //return true;
    }
    public void sendEmail(string messageBody,string email,string subject)
    {
        //MailMessage mail = new MailMessage();
        //mail.To.Add(email);
        ////mail.Bcc.Add(ConfigurationManager.AppSettings["apcspccmailid"]);
        ////mail.From = new MailAddress(sEmail);
        //mail.From = new MailAddress("jeevandangroup@gmail.com");
        //mail.Subject = subject;
        //string sBody = "<table style='width: 636px' bgcolor='#EAEAEA'><tr><td><table ><tr><td ><span style='font-family:Tekton Pro; font-size:35px; color: #057092;'>Jeevandan</span>  <span style='font-family:Lucida Bright; font-style:italic; color:red;font-size: medium'>&nbsp;&nbsp;Cadavar Transplantation Programme</span></td></tr><tr><td  > <span style='font-family:Arial; font-size:18px; color: #52665A;'><strong>Govt. of Andhra Pradesh</strong></span></td></tr></table></td></tr><tr><td> " + messageBody + "</td></tr><tr><td><table width='100%'><tr><td><table style='font-size: x-small; color: #999999; font-family: Arial, Helvetica, sans-serif'><tr><td>This message was sent to " + email + "</td></tr><tr><td>2014 Jeevandan | <a target='_blank' href='http://jeevandan.gov.in/ContactUs.htm'> Contact Us</a></td></tr><tr><td>Jeevandan.gov.in,Nizams Institute of Medical Sciences,Punjagutta, Hyderabad, A.P.</td></tr></table></td><td align='right'>    <img src='http://jeevandan.gov.in/images/JeeLogo.jpg' style='height: 70px; width: 92px' /></td></tr></table></td></tr></table>";
        //mail.Body = sBody;
        //mail.IsBodyHtml = true;
        //SmtpClient smtp = new SmtpClient();
        //smtp.Host = "relay.nic.in"; //Or Your SMTP Server Address
        //smtp.Port = 25;

        ////SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        ////smtp.Credentials = new System.Net.NetworkCredential("jeevandangroup@gmail.com", "Jeev@2013");
        ////smtp.EnableSsl = true;
        ////smtp.Port = 587;

        //smtp.EnableSsl = false;
        //try
        //{
        //    smtp.Send(mail);
        //}
        //catch
        //{
        //    smtp.Host = "164.100.14.95";
        //    smtp.Send(mail);
        //}
       
    }
    public void sendEmail(string messageBody, string email, string subject,string attachmentName)
    {
        //MailMessage mail = new MailMessage();
        //mail.To.Add(email);
        ////mail.Bcc.Add(ConfigurationManager.AppSettings["apcspccmailid"]);
        ////mail.From = new MailAddress(sEmail);
        //mail.From = new MailAddress("jeevandangroup@gmail.com");
        //mail.Subject = subject;
        //string sBody = "<table style='width: 636px' bgcolor='#EAEAEA'><tr><td><table ><tr><td ><span style='font-family:Tekton Pro; font-size:35px; color: #057092;'>Jeevandan</span>  <span style='font-family:Lucida Bright; font-style:italic; color:red;font-size: medium'>&nbsp;&nbsp;Cadavar Transplantation Programme</span></td></tr><tr><td  > <span style='font-family:Arial; font-size:18px; color: #52665A;'><strong>Govt. of Andhra Pradesh</strong></span></td></tr></table></td></tr><tr><td> " + messageBody + "</td></tr><tr><td><table width='100%'><tr><td><table style='font-size: x-small; color: #999999; font-family: Arial, Helvetica, sans-serif'><tr><td>This message was sent to " + email + "</td></tr><tr><td>2014 Jeevandan | <a target='_blank' href='http://jeevandan.gov.in/ContactUs.htm'> Contact Us</a></td></tr><tr><td>Jeevandan.gov.in,Nizams Institute of Medical Sciences,Punjagutta, Hyderabad, A.P.</td></tr></table></td><td align='right'>    <img src='http://jeevandan.gov.in/images/JeeLogo.jpg' style='height: 70px; width: 92px' /></td></tr></table></td></tr></table>";
        //Attachment attachment = new Attachment(attachmentName);
        //mail.Attachments.Add(attachment);
        //mail.Body = sBody;
        //mail.IsBodyHtml = true;
        //SmtpClient smtp = new SmtpClient();
        //smtp.Host = "relay.nic.in"; //Or Your SMTP Server Address
        //smtp.Port = 25;

        ////SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        ////smtp.Credentials = new System.Net.NetworkCredential("jeevandangroup@gmail.com", "Jeev@2013");
        ////smtp.EnableSsl = true;
        ////smtp.Port = 587;

        //smtp.EnableSsl = false;
        //try
        //{
        //    smtp.Send(mail);
        //}
        //catch
        //{
        //    smtp.Host = "164.100.14.95";
        //    smtp.Send(mail);
        //}
    }
}