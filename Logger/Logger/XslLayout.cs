using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Layout;


namespace Logger4net
{
    public class XslLayout : LayoutSkeleton
    {

        public override void ActivateOptions()
        {
            
        }
        public override void Format(System.IO.TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            writer.Write("<log>");
            writer.Write("<datetime>" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</datetime>");
            writer.Write("<level>" + loggingEvent.Level.DisplayName + "</level>");
            writer.Write("<message>");
            loggingEvent.WriteRenderedMessage(writer);
            writer.Write("</message>");
            writer.Write("</log>");
            writer.WriteLine();
        }

        public override string Header
        {
            get
            {
                StringBuilder _Header = new StringBuilder();
                _Header.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                _Header.Append("<?xml-stylesheet href=\"D:\\log.xsl\" type=\"text/xsl\"?>");
                //_Header.Append("<?xml-stylesheet href=\"D:\\log.xsl\" type=\"html/xsl\"?>");
                _Header.Append("<logs>");
                _Header.Append("<header>Started logging at " + DateTime.Now + "</header>" + System.Environment.NewLine);
                return _Header.ToString();
            }
            set
            {
                base.Header = value;
            }
        }

        public override string Footer
        {
            get
            {   StringBuilder _Footer = new StringBuilder();
                _Footer.Append("<footer>Stopped logging at " + DateTime.Now + "</footer>");
                _Footer.Append("</logs>");
                return _Footer.ToString();
            }
            set
            {
                base.Footer = value;
            }
        }
    }
}
