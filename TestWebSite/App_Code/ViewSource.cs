//====================================================================
//
// COPYRIGHT (C) 2003 OPINIONATEDGEEK
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
//  File name:		$RCSfile$
//
//  VSS File:		$Source$
//
//  Last Modified:	$Date$
//
//  Author:			$Author$
//
//  Version:		$Revision$
//
//====================================================================

namespace OpinionatedGeek.Site
{
	using System;
	using System.Drawing;
	using System.IO;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using OpinionatedGeek.Web.PowerPack;

	public class ViewSource : CollapsiblePanel
	{
		//============================================================
		// Private Data
		//============================================================

		private const string CACHE_KEY_PREFIX = "PageSource-";

		//============================================================
		// Constructors
		//============================================================

		public ViewSource
		(
		)
		{
			this.Text = " View ASPX Source (click to expand)";
			this.Width = Unit.Parse ("100%");
			this.BackColor = ColorTranslator.FromHtml ("#FF9900");
			this.TitleStyle.BackColor = ColorTranslator.FromHtml ("#FF9900");
			this.TitleStyle.ForeColor = Color.White;
			this.TitleStyle.Decoration = "none";
			this.TitleStyle.Font.Bold = true;
			this.BodyStyle.BackColor = ColorTranslator.FromHtml ("#F9F9F9");

			return;
		}

		//============================================================
		// Properties
		//============================================================

		//============================================================
		// Events
		//============================================================

		protected override void OnLoad
		(
			EventArgs e
		)
		{
			base.OnLoad (e);

			this.AddParsedSubObject (new LiteralControl (GetContents ()));

			return;
		}

		//============================================================
		// Methods
		//============================================================

		private string GetContents
		(
		)
		{
			string szPageFilename = this.Context.Request.FilePath;
			string szFileContents = GetCacheContents (szPageFilename);
			if (szFileContents == null)
			{
				szFileContents = GetFileContents (szPageFilename);
				szFileContents = SyntaxHighlightContents (szFileContents);
				SetCacheContents (szPageFilename, szFileContents);
			}

			return szFileContents;
		}

		private string SyntaxHighlightContents
		(
			string szFileContents
		)
		{
			string szHtml = HtmlEncodeContents (szFileContents);

			szHtml = Regex.Replace (szHtml, "&lt;%[^%]*%&gt;", new MatchEvaluator (MakeYellowBack), RegexOptions.None);
			szHtml = Regex.Replace (szHtml, "&lt;[^%@][^&]*&gt;", new MatchEvaluator (ParseTag), RegexOptions.IgnoreCase | RegexOptions.Multiline);
			szHtml = Regex.Replace (szHtml, "/?&gt;", new MatchEvaluator (MakeBlueText), RegexOptions.None);
			szHtml = Regex.Replace (szHtml, "&lt;/?", new MatchEvaluator (MakeBlueText), RegexOptions.None);

			return "<pre>" + szHtml + "</pre>";
		}

		private string ParseTag
		(
			Match mMatch
		)
		{
			string szTag = mMatch.Value;
			string szTagContents = szTag.Substring (4, szTag.Length - 8);
			szTagContents = Regex.Replace (szTagContents, "(([\\p{Ll}\\p{Lu}\\p{Lt}\\p{Lo}\\p{Nd}\\p{Pc}-]+)=([\"']?[^\"]+[\"']?))+", new MatchEvaluator (MakeAttributeText), RegexOptions.IgnoreCase);

			return "<font color=\"maroon\">&lt;" + szTagContents + "&gt;</font>";
		}

		private string MakeAttributeText
		(
			Match mMatch
		)
		{
			return "<font color=\"red\">" + mMatch.Groups [2].Value + "</font><font color=\"blue\">=" + mMatch.Groups [3].Value + "</font>";
		}

		private string MakeBlueText
		(
			Match mMatch
		)
		{
			return "<font color=\"blue\">" + mMatch.Value + "</font>";
		}

		private string MakeYellowBack
		(
			Match mMatch
		)
		{
			return "<span style=\"background-color: yellow;\">" + mMatch.Value + "</span>";
		}

		private string GetCacheContents
		(
			string szPageFilename
		)
		{
			string szCachedVersion = this.Context.Cache [CACHE_KEY_PREFIX + szPageFilename] as string;

			return szCachedVersion;
		}

		private void SetCacheContents
		(
			string szPageFilename,
			string szSyntaxHighlightedContents
		)
		{
			this.Context.Cache.Insert (CACHE_KEY_PREFIX + szPageFilename, szSyntaxHighlightedContents, null, DateTime.MaxValue, TimeSpan.FromHours (1)) ;

			return;
		}

		private string GetFileContents
		(
			string szPageFilename
		)
		{
			szPageFilename = this.Context.Request.MapPath (szPageFilename);

			StreamReader srFile = null;
			string szFileContents = String.Empty;
			try
			{
				srFile = File.OpenText (szPageFilename);
				szFileContents = srFile.ReadToEnd ();
			}
			finally
			{
				if (srFile != null)
				{
					srFile.Close ();
				}
			}

			return szFileContents;
		}

		private string HtmlEncodeContents
		(
			string szContents
		)
		{
			string szWorking = szContents;
			szWorking = szWorking.Replace ("&", "&amp;");
			szWorking = szWorking.Replace ("<", "&lt;");
			szWorking = szWorking.Replace (">", "&gt;");

			return szWorking;
		}
	}
}
