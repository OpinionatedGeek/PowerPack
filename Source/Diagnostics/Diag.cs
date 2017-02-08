//====================================================================
//
// COPYRIGHT (C) 2003 - 2008 OPINIONATEDGEEK LTD.
//
// The contents of this file are subject to License from OpinionatedGeek;
// you may not use this file except in compliance with the License.
// You may obtain a License from OpinionatedGeek Ltd.  Software distributed
// under the License is distributed "as is" and without any warranty
// as to merchantability or fitness for a particular purpose or any
// other warranties either expressed or implied.  The author will
// not be liable for data loss, damages, loss of profits or any
// other kind of loss while using or misusing this software.
//
// For more information visit http://www.opinionatedgeek.com/
//
//====================================================================
//
//  ID:             $Id$
//
//  URL:            $URL$
//
//  Last Modified:  $Date$
//
//  Author:         $Author$
//
//  Revision:       $Revision$
//
//====================================================================

using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class Diag
    {
        //============================================================
        // Private Data
        //============================================================

        //============================================================
        // Constructors
        //============================================================

        private Diag ()
        {
            return;
        }

        //============================================================
        // Static Methods
        //============================================================

        [Conditional ("DEBUG")]
        public static void EmptyMethod ()
        {
            string caller = GetCaller ();

            DebugWriter ("Empty method", caller);

            return;
        }

        [Conditional ("DEBUG")]
        public static void EmptyMethod (string format, params object[] parameters)
        {
            string caller = GetCaller ();
            string formatted = String.Format (Globalisation.GetCultureInfo (), format, parameters);

            DebugWriter (formatted, caller);

            return;
        }

        [Conditional ("DEBUG")]
        public static void Exception (Exception exception)
        {
            string caller = GetCaller ();

            DebugWriter (exception.ToString (), caller);

            return;
        }

        [Conditional ("DEBUG")]
        public static void Exception (Exception exception, string format, params object[] parameters)
        {
            string caller = GetCaller ();
            string formatted = String.Format (Globalisation.GetCultureInfo (), format, parameters);

            DebugWriter (formatted + exception, caller);

            return;
        }

        [Conditional ("DEBUG")]
        public static void MethodEntered ()
        {
            string caller = GetCaller ();

            DebugWriter ("Method entered", caller);

            return;
        }

        [Conditional ("DEBUG")]
        public static void MethodEntered (string format, params object[] parameters)
        {
            string caller = GetCaller ();
            string formatted = String.Format (Globalisation.GetCultureInfo (), format, parameters);

            DebugWriter (formatted, caller);

            return;
        }

        [Conditional ("DEBUG")]
        public static void MethodExited ()
        {
            string caller = GetCaller ();

            DebugWriter ("Method exited", caller);

            return;
        }

        [Conditional ("DEBUG")]
        public static void MethodExited (string format, params object[] parameters)
        {
            string caller = GetCaller ();
            string formatted = String.Format (Globalisation.GetCultureInfo (), format, parameters);

            DebugWriter (formatted, caller);

            return;
        }

//		[Conditional("DEBUG")]
//		public static void MessageBox
//		(
//			string szFormat,
//			params object [] aoParams
//		)
//		{
//			string szCaller = GetCaller ();
//			string szFormatted = String.Format (szFormat, aoParams);
//			StackTrace stCurrentStack = new StackTrace ();
//			szFormatted += "\n" + stCurrentStack.ToString ();
//
//			System.Windows.Forms.MessageBox.Show (szCaller + ": " + szFormatted, "Debug", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
//
//			return;
//		}

        [Conditional ("DEBUG")]
        public static void Information (string format, params object[] parameters)
        {
            string caller = GetCaller ();
            string formatted = String.Format (Globalisation.GetCultureInfo (), format, parameters);

            DebugWriter (formatted, caller);

            return;
        }

        [Conditional ("DEBUG")]
        public static void Warning (string format, params object[] parameters)
        {
            string caller = GetCaller ();
            string formatted = String.Format (Globalisation.GetCultureInfo (), format, parameters);

            DebugWriter (formatted, caller);

            return;
        }

        private static string GetCaller ()
        {
            var formatted = new StringBuilder (String.Empty);
            var currentStack = new StackTrace ();
            StackFrame callingFrame = currentStack.GetFrame (2);
            MethodBase callingMethod = callingFrame.GetMethod ();

            // Collapse namespaces so they don't smother us.
            string[] parts = callingMethod.DeclaringType.ToString ().Split ('.');
            for (int partCounter = 0; partCounter < (parts.Length - 1); partCounter++)
            {
                formatted.Append (parts [partCounter] [0]);
                formatted.Append (".");
            }

            formatted.Append (parts [parts.Length - 1]);
            formatted.Append (".");
            formatted.Append (callingMethod.Name);

            string threadName = Thread.CurrentThread.Name;
            if (threadName != null)
            {
                formatted.Append (" [");
                formatted.Append (threadName);
                formatted.Append ("]");
            }

            return formatted.ToString ();
        }

        //public static string GetStackTrace
        //(
        //)
        //{
        //    StackTrace currentStack = new StackTrace ();
        //    StringBuilder stackTrace = new StringBuilder ("");
        //    StackFrame requestedFrame;
        //    MethodBase method;
        //    for (int frameCounter = 1; frameCounter < currentStack.FrameCount; frameCounter++)
        //    {
        //        requestedFrame = currentStack.GetFrame (frameCounter);
        //        method = requestedFrame.GetMethod ();
        //        stackTrace.Append (method.DeclaringType);
        //        stackTrace.Append (".");
        //        stackTrace.Append (method.Name);
        //        stackTrace.Append ("\n");
        //    }

        //    return stackTrace.ToString ();
        //}

        private static void DebugWriter (string formatted, string caller)
        {
            HttpContext.Current.Trace.Write (caller, formatted);

            return;
        }
    }
}