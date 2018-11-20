<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GD_atnRules.aspx.vb" Inherits="GD_atnRules" title="ISGEC: Attendance Rules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
<div id="div1" class="page">
    <div id="div2" class="caption">
					<asp:Label ID="LabelatnAppliedApplications" runat="server" Font-Bold="True" Font-Size="14px"  Text="Leave Rules"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
  <ContentTemplate>
        <LGM:ToolBar0 
          ID="ToolBar0_1" 
          ToolType="lgNReport"
          EnableAdd="False" 
          runat="server" />
    <div id="frmdiv" class="ui-widget-content minipage">
	<p class=MsoListParagraphCxSpFirst style='margin-bottom:6.0pt;mso-add-space:
auto;text-align:justify;text-indent:-18.0pt;line-height:normal;mso-list:l1 level1 lfo1;
tab-stops:36.0pt;mso-layout-grid-align:none'><![if !supportLists]><b
style='mso-bidi-font-weight:normal'><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:Cambria;mso-bidi-font-family:
Cambria'><span style='mso-list:Ignore'>1.<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><![endif]><b style='mso-bidi-font-weight:normal'><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>Punching Rules:<o:p></o:p></span></b></p>

<p class=MsoListParagraphCxSpMiddle style='margin-bottom:6.0pt;mso-add-space:
auto;text-align:justify;line-height:normal;tab-stops:36.0pt'><b
style='mso-bidi-font-weight:normal'><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>Noida office-</span></b><span lang=EN-US
style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'> </span><span lang=EN-US
style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-top:0cm;margin-right:0cm;
margin-bottom:6.0pt;margin-left:72.0pt;mso-add-space:auto;text-align:justify;
text-indent:-18.0pt;line-height:normal;mso-list:l1 level2 lfo1;tab-stops:36.0pt'><![if !supportLists]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
Cambria;mso-bidi-font-family:Cambria'><span style='mso-list:Ignore'>a.<span
style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>Office timings from 8:45 a.m. to
5:30 p.m. including 30 minutes lunch break<span style='mso-spacerun:yes'>    
</span>(1:00 – 1:30).<span style='mso-spacerun:yes'>  </span></span><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-bottom:6.0pt;mso-add-space:
auto;text-align:justify;line-height:normal;tab-stops:36.0pt'><span lang=EN-US
style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-top:0cm;margin-right:0cm;
margin-bottom:6.0pt;margin-left:72.0pt;mso-add-space:auto;text-align:justify;
text-indent:-18.0pt;line-height:normal;mso-list:l1 level2 lfo1;tab-stops:36.0pt'><![if !supportLists]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
Cambria;mso-bidi-font-family:Cambria'><span style='mso-list:Ignore'>b.<span
style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'>&nbsp;</span><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>Employees are expected to punch their card every
day, while entering or leaving the office premises, unless they are on outdoor
duty or tour.<span style='mso-spacerun:yes'>  </span>First punch in the day
will be treated as IN PUNCH and last punch in the day will be taken as OUT
PUNCH.</span><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='text-align:justify;tab-stops:36.0pt'><span
lang=EN-US style='font-size:12.0pt;line-height:115%;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-top:0cm;margin-right:0cm;
margin-bottom:6.0pt;margin-left:72.0pt;mso-add-space:auto;text-align:justify;
text-indent:-18.0pt;line-height:normal;mso-list:l1 level2 lfo1;tab-stops:36.0pt'><![if !supportLists]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
Cambria;mso-bidi-font-family:Cambria'><span style='mso-list:Ignore'>c.<span
style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><span style='mso-spacerun:yes'> </span></span><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>In case IN PUNCH is between (8:45
am and 9:15 am, employee is required to make up time lost due to late arrival
by completing 8 hours &amp; 45 minutes or else 2<sup>nd</sup> half will be
marked as leave.<span style='mso-spacerun:yes'>  </span>For example, if arrival
is at 9:10 am he/she will be marked present provided he/she punches out at 5:55
pm (i.e. 5:30 pm + 25 minutes).</span><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='text-align:justify;tab-stops:36.0pt'><span
lang=EN-US style='font-size:12.0pt;line-height:115%;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-top:0cm;margin-right:0cm;
margin-bottom:6.0pt;margin-left:72.0pt;mso-add-space:auto;text-align:justify;
text-indent:-18.0pt;line-height:normal;mso-list:l1 level2 lfo1;tab-stops:36.0pt;
mso-layout-grid-align:none'><![if !supportLists]><b style='mso-bidi-font-weight:
normal'><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:Cambria;mso-bidi-font-family:Cambria'><span
style='mso-list:Ignore'>d.<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><![endif]><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>In case IN PUNCH is later than 9:15am, first half
will be treated as on leave.<span style='mso-spacerun:yes'>  </span>However,
three late punches <span class=SpellE>upto</span> 10:15am will be allowed in a
calendar month provided the employee completes 8 hours &amp; 45 minutes of<span
style='mso-spacerun:yes'>  </span>presence on the same day, else half day will
be marked as leave.<b style='mso-bidi-font-weight:normal'><o:p></o:p></b></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-bottom:6.0pt;mso-add-space:
auto;text-align:justify;line-height:normal;tab-stops:36.0pt;mso-layout-grid-align:
none'><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-bottom:6.0pt;mso-add-space:
auto;text-align:justify;line-height:normal;tab-stops:36.0pt'><b
style='mso-bidi-font-weight:normal'><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>Chennai &amp; Pune Offices –</span></b><b
style='mso-bidi-font-weight:normal'><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></b></p>

<p class=MsoListParagraphCxSpMiddle style='margin-top:0cm;margin-right:0cm;
margin-bottom:6.0pt;margin-left:72.0pt;mso-add-space:auto;text-align:justify;
text-indent:-18.0pt;line-height:normal;mso-list:l0 level1 lfo4;tab-stops:36.0pt'><![if !supportLists]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
Cambria;mso-bidi-font-family:Cambria'><span style='mso-list:Ignore'>a.<span
style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>Office timings from 9:00 a.m. to
5:45 p.m. including 30 minutes lunch break.<span style='mso-spacerun:yes'> 
</span>As such daily 8 hours 45 minutes of presence (including lunch) is
officially required on any given day.</span><span lang=EN-US style='font-size:
12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-top:0cm;margin-right:0cm;
margin-bottom:6.0pt;margin-left:72.0pt;mso-add-space:auto;text-align:justify;
line-height:normal;tab-stops:36.0pt'><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-top:0cm;margin-right:0cm;
margin-bottom:6.0pt;margin-left:72.0pt;mso-add-space:auto;text-align:justify;
text-indent:-18.0pt;line-height:normal;mso-list:l0 level1 lfo4;tab-stops:36.0pt'><![if !supportLists]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
Cambria;mso-bidi-font-family:Cambria'><span style='mso-list:Ignore'>b.<span
style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>Employees are expected to punch
their card every day, while entering or leaving the office premises, unless
they are on outdoor duty or tour.<span style='mso-spacerun:yes'>  </span>First
punch in the day will be treated as IN PUNCH and last punch in the day will be
taken as OUT PUNCH.</span><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoListParagraphCxSpMiddle><span lang=EN-US style='font-size:12.0pt;
line-height:115%;font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-top:0cm;margin-right:0cm;
margin-bottom:6.0pt;margin-left:72.0pt;mso-add-space:auto;text-align:justify;
text-indent:-18.0pt;line-height:normal;mso-list:l0 level1 lfo4;tab-stops:36.0pt'><![if !supportLists]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
Cambria;mso-bidi-font-family:Cambria'><span style='mso-list:Ignore'>c.<span
style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>In case IN PUNCH is between (9:00
am and 9:30 am, employee is required to make up time lost due to late arrival
by completing 8 hours &amp; 45 minutes or else 2<sup>nd</sup> half will be
marked as leave.<span style='mso-spacerun:yes'>  </span>For example, if arrival
is at 9:25 am he/she will be marked present provided he/she punches out at 6:10
pm (i.e. 5:45 pm + 25 minutes).</span><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoListParagraphCxSpMiddle><span lang=EN-US style='font-size:12.0pt;
line-height:115%;font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpLast style='margin-top:0cm;margin-right:0cm;
margin-bottom:6.0pt;margin-left:72.0pt;mso-add-space:auto;text-align:justify;
text-indent:-18.0pt;line-height:normal;mso-list:l0 level1 lfo4;tab-stops:36.0pt'><![if !supportLists]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
Cambria;mso-bidi-font-family:Cambria'><span style='mso-list:Ignore'>d.<span
style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span><![endif]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>In case IN PUNCH is later than
9:30am, first half will be treated as on leave.<span style='mso-spacerun:yes'> 
</span>However, three late punches <span class=SpellE>upto</span> 10:30am will
be allowed in a calendar month provided the employee completes 8 hours &amp; 45
minutes of<span style='mso-spacerun:yes'>  </span>presence on the same day,
else half day will be marked as leave.</span><span lang=EN-US style='font-size:
12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='margin-top:0cm;margin-right:0cm;margin-bottom:6.0pt;
margin-left:90.0pt;text-align:justify;text-indent:-63.0pt;line-height:normal;
tab-stops:36.0pt list 90.0pt'><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpFirst style='margin-bottom:6.0pt;mso-add-space:
auto;text-align:justify;text-indent:-18.0pt;line-height:normal;mso-list:l1 level1 lfo1;
tab-stops:36.0pt'><![if !supportLists]><b style='mso-bidi-font-weight:normal'><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
Cambria;mso-bidi-font-family:Cambria'><span style='mso-list:Ignore'>2.<span
style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></b><![endif]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>As such daily 8 hours 45 minutes
of presence (including lunch) is officially required on any given day.</span><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-bottom:6.0pt;mso-add-space:
auto;text-align:justify;line-height:normal;tab-stops:36.0pt'><span lang=EN-US
style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-bottom:6.0pt;mso-add-space:
auto;text-align:justify;text-indent:-18.0pt;line-height:normal;mso-list:l1 level1 lfo1;
tab-stops:36.0pt'><![if !supportLists]><b style='mso-bidi-font-weight:normal'><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
Cambria;mso-bidi-font-family:Cambria'><span style='mso-list:Ignore'>3.<span
style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></b><![endif]><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>In case the employee forgets to
punch in the Morning OR evening, the same<b style='mso-bidi-font-weight:normal'>
is to be regularized within 3 days of such miss out</b>.<span
style='mso-spacerun:yes'>  </span>Such miss-outs will be permitted <span
class=SpellE>upto</span> 3 times in a month.</span><span lang=EN-US
style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='margin-bottom:6.0pt;mso-add-space:
auto;text-align:justify;line-height:normal;tab-stops:36.0pt'><span lang=EN-US
style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='text-align:justify;tab-stops:36.0pt'><span
lang=EN-US style='font-size:12.0pt;line-height:115%;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='mso-margin-top-alt:auto;mso-margin-bottom-alt:
auto;mso-add-space:auto;text-align:justify;text-indent:-18.0pt;line-height:
normal;mso-list:l1 level1 lfo1;tab-stops:36.0pt'><![if !supportLists]><b
style='mso-bidi-font-weight:normal'><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:Cambria;mso-bidi-font-family:
Cambria'><span style='mso-list:Ignore'>4.<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><![endif]><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>In order to facilitate employees for availing short
leave to attend to urgent situations, short leave <span class=SpellE>upto</span>
two times in a month for two hours each either in Morning or Evening with prior
sanction of HOD is permitted.<span style='mso-spacerun:yes'>  </span>However,
the concerned employee is required to compensate for the lost time within next
6 working days.<o:p></o:p></span></p>

<p class=MsoListParagraphCxSpMiddle><span lang=EN-US style='font-size:12.0pt;
line-height:115%;font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'><o:p>&nbsp;</o:p></span></p>

<p class=MsoListParagraphCxSpMiddle style='mso-margin-top-alt:auto;mso-margin-bottom-alt:
auto;mso-add-space:auto;text-align:justify;text-indent:-18.0pt;line-height:
normal;mso-list:l1 level1 lfo1;tab-stops:36.0pt'><![if !supportLists]><b
style='mso-bidi-font-weight:normal'><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:Cambria;mso-bidi-font-family:
Cambria'><span style='mso-list:Ignore'>5.<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><![endif]><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>For Cat XI &amp; XII, intervening holidays/weekly
off will not be counted towards leave.<span style='mso-spacerun:yes'> 
</span>For Example, if person goes on leave for 5 days &amp; Sunday is <span
class=SpellE>interving</span> then he will be regularized to apply leave for
4days only. <span style='mso-spacerun:yes'> </span></span><span lang=EN-US
style='font-size:12.0pt;font-family:"Cambria","serif"'><o:p></o:p></span></p>

<p class=MsoListParagraphCxSpLast><span lang=EN-US style='font-size:12.0pt;
line-height:115%;font-family:"Cambria","serif"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal style='mso-margin-top-alt:auto;margin-bottom:6.0pt;
margin-left:36.0pt;text-align:justify;text-indent:-18.0pt;line-height:normal;
mso-list:l1 level1 lfo1;tab-stops:27.0pt 36.0pt'><![if !supportLists]><b
style='mso-bidi-font-weight:normal'><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:Cambria;mso-bidi-font-family:
Cambria'><span style='mso-list:Ignore'>6.<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><![endif]><b style='mso-bidi-font-weight:normal'><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'><span
style='mso-spacerun:yes'> </span><u>Leave Scope and eligibility</u>:</span></b><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
text-align:justify;text-indent:27.0pt;line-height:150%'><span lang=EN-US
style='font-size:12.0pt;line-height:150%;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:Arial'>Permanent
employees are eligible for the following types of leave: </span><span
lang=EN-US style='font-size:12.0pt;line-height:150%;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
margin-left:27.0pt;text-align:justify;line-height:normal;tab-stops:27.0pt 54.0pt'><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>a) <span style='mso-tab-count:
1'>     </span>Casual leaves <span style='mso-tab-count:4'>                                          </span><span
style='mso-spacerun:yes'>    </span>b)<span style='mso-tab-count:1'>    </span>Privilege
Leave</span><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='margin-top:0cm;margin-right:0cm;margin-bottom:6.0pt;
margin-left:54.0pt;text-align:justify;text-indent:-27.0pt;line-height:150%;
tab-stops:216.0pt'><span lang=EN-US style='font-size:12.0pt;line-height:150%;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>c) <span style='mso-tab-count:1'>     </span>Sick
leave <span style='mso-tab-count:2'>                                                </span><span
style='mso-spacerun:yes'>    </span>d)<span style='mso-tab-count:1'>    </span>Maternity
leave<o:p></o:p></span></p>

<p class=MsoNormal style='margin-top:0cm;margin-right:0cm;margin-bottom:6.0pt;
margin-left:54.0pt;text-align:justify;text-indent:-27.0pt;line-height:150%;
tab-stops:216.0pt'><b style='mso-bidi-font-weight:normal'><u><span lang=EN-US
style='font-size:12.0pt;line-height:150%;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:Arial'>Quantum
of leave</span></u></b><b style='mso-bidi-font-weight:normal'><span lang=EN-US
style='font-size:12.0pt;line-height:150%;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:Arial'>:</span></b><span
lang=EN-US style='font-size:12.0pt;line-height:150%;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:Arial'><o:p></o:p></span></p>

<table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=691
 style='width:518.0pt;margin-left:-12.6pt;border-collapse:collapse;mso-yfti-tbllook:
 1184;mso-padding-alt:0cm 5.4pt 0cm 5.4pt'>
 <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;height:54.75pt'>
  <td width=64 style='width:47.65pt;border:solid black 1.0pt;mso-border-alt:
  solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:54.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><b><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>S. No.<o:p></o:p></span></b></p>
  </td>
  <td width=96 style='width:72.0pt;border:solid black 1.0pt;border-left:none;
  mso-border-top-alt:solid black .5pt;mso-border-bottom-alt:solid black .5pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  54.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><b><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Type of Leave<o:p></o:p></span></b></p>
  </td>
  <td width=125 style='width:94.05pt;border:solid black 1.0pt;border-left:none;
  mso-border-top-alt:solid black .5pt;mso-border-bottom-alt:solid black .5pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  54.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><b><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>No. of days<o:p></o:p></span></b></p>
  </td>
  <td width=109 style='width:81.4pt;border:solid black 1.0pt;border-left:none;
  mso-border-top-alt:solid black .5pt;mso-border-bottom-alt:solid black .5pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  54.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><b><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Carried Forward in a year<o:p></o:p></span></b></p>
  </td>
  <td width=120 style='width:90.15pt;border:solid black 1.0pt;border-left:none;
  mso-border-top-alt:solid black .5pt;mso-border-bottom-alt:solid black .5pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  54.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><b><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Maximum Accumulation allowed<o:p></o:p></span></b></p>
  </td>
  <td width=177 style='width:132.75pt;border:solid black 1.0pt;border-left:
  none;mso-border-top-alt:solid black .5pt;mso-border-bottom-alt:solid black .5pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  54.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><b><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Encashment of leave<o:p></o:p></span></b></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:1;height:41.25pt'>
  <td width=64 style='width:47.65pt;border:solid black 1.0pt;border-top:none;
  mso-border-left-alt:solid black .5pt;mso-border-bottom-alt:solid black .5pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  41.25pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>1<o:p></o:p></span></p>
  </td>
  <td width=96 style='width:72.0pt;border-top:none;border-left:none;border-bottom:
  solid black 1.0pt;border-right:solid black 1.0pt;mso-border-bottom-alt:solid black .5pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  41.25pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Casual<o:p></o:p></span></p>
  </td>
  <td width=125 style='width:94.05pt;border-top:none;border-left:none;
  border-bottom:solid black 1.0pt;border-right:solid black 1.0pt;mso-border-bottom-alt:
  solid black .5pt;mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:41.25pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>7 days<o:p></o:p></span></p>
  </td>
  <td width=109 style='width:81.4pt;border-top:none;border-left:none;
  border-bottom:solid black 1.0pt;border-right:solid black 1.0pt;mso-border-bottom-alt:
  solid black .5pt;mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:41.25pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Nil<o:p></o:p></span></p>
  </td>
  <td width=120 style='width:90.15pt;border-top:none;border-left:none;
  border-bottom:solid black 1.0pt;border-right:solid black 1.0pt;mso-border-bottom-alt:
  solid black .5pt;mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:41.25pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Nil<o:p></o:p></span></p>
  </td>
  <td width=177 style='width:132.75pt;border-top:none;border-left:none;
  border-bottom:solid black 1.0pt;border-right:solid black 1.0pt;mso-border-bottom-alt:
  solid black .5pt;mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:41.25pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Nil<o:p></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:2;height:39.55pt'>
  <td width=64 style='width:47.65pt;border:solid black 1.0pt;border-top:none;
  mso-border-left-alt:solid black .5pt;mso-border-bottom-alt:solid black .5pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  39.55pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>2<o:p></o:p></span></p>
  </td>
  <td width=96 style='width:72.0pt;border-top:none;border-left:none;border-bottom:
  solid black 1.0pt;border-right:solid black 1.0pt;mso-border-bottom-alt:solid black .5pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  39.55pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Sick<o:p></o:p></span></p>
  </td>
  <td width=125 style='width:94.05pt;border-top:none;border-left:none;
  border-bottom:solid black 1.0pt;border-right:solid black 1.0pt;mso-border-bottom-alt:
  solid black .5pt;mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:39.55pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>8 days<o:p></o:p></span></p>
  </td>
  <td width=109 style='width:81.4pt;border-top:none;border-left:none;
  border-bottom:solid black 1.0pt;border-right:solid black 1.0pt;mso-border-bottom-alt:
  solid black .5pt;mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:39.55pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>8 days<o:p></o:p></span></p>
  </td>
  <td width=120 style='width:90.15pt;border-top:none;border-left:none;
  border-bottom:solid black 1.0pt;border-right:solid black 1.0pt;mso-border-bottom-alt:
  solid black .5pt;mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:39.55pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>30 days<o:p></o:p></span></p>
  </td>
  <td width=177 style='width:132.75pt;border:none;border-right:solid black 1.0pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  39.55pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span class=SpellE><span lang=EN-US
  style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
  "Times New Roman";mso-bidi-font-family:Arial'>Unavailed</span></span><span
  lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
  "Times New Roman";mso-bidi-font-family:Arial'> SL of <span class=SpellE>Cat.XI</span>
  &amp; XII can be en-cashed every year.<o:p></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:3;height:17.25pt'>
  <td width=64 style='width:47.65pt;border-top:none;border-left:solid black 1.0pt;
  border-bottom:none;border-right:solid black 1.0pt;mso-border-left-alt:solid black .5pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  17.25pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>3<o:p></o:p></span></p>
  </td>
  <td width=627 colspan=5 style='width:470.35pt;border-top:none;border-left:
  none;border-bottom:solid windowtext 1.0pt;border-right:solid black 1.0pt;
  mso-border-top-alt:solid black .5pt;mso-border-top-alt:solid black .5pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid black .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:17.25pt'>
  <p class=MsoNormal align=center style='margin-bottom:0cm;margin-bottom:.0001pt;
  text-align:center;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Privilege<o:p></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:4;height:42.75pt'>
  <td width=64 style='width:47.65pt;border:solid windowtext 1.0pt;mso-border-alt:
  solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:42.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>3(a)<o:p></o:p></span></p>
  </td>
  <td width=96 nowrap style='width:72.0pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:42.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Calibri'>HO Posted<o:p></o:p></span></p>
  </td>
  <td width=125 style='width:94.05pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:42.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>30 calendar days<o:p></o:p></span></p>
  </td>
  <td width=109 style='width:81.4pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:42.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>24 days<o:p></o:p></span></p>
  </td>
  <td width=120 style='width:90.15pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:42.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>90 days<o:p></o:p></span></p>
  </td>
  <td width=177 style='width:132.75pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:42.75pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>In excess of 90 days is automatically en-cashed<o:p></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:5;height:35.05pt'>
  <td width=64 style='width:47.65pt;border:solid windowtext 1.0pt;border-top:
  none;mso-border-left-alt:solid windowtext .5pt;mso-border-bottom-alt:solid windowtext .5pt;
  mso-border-right-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:35.05pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>3(b)<o:p></o:p></span></p>
  </td>
  <td width=96 nowrap style='width:72.0pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:35.05pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Calibri'>Site Posted<o:p></o:p></span></p>
  </td>
  <td width=125 style='width:94.05pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:35.05pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>30 calendar days<o:p></o:p></span></p>
  </td>
  <td width=109 style='width:81.4pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:35.05pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>30 days<o:p></o:p></span></p>
  </td>
  <td width=120 style='width:90.15pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:35.05pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>90 days<o:p></o:p></span></p>
  </td>
  <td width=177 style='width:132.75pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:35.05pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>&nbsp;<o:p></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:6;height:31.0pt'>
  <td width=64 style='width:47.65pt;border:solid windowtext 1.0pt;border-top:
  none;mso-border-left-alt:solid windowtext .5pt;mso-border-bottom-alt:solid windowtext .5pt;
  mso-border-right-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:31.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>3(c)<o:p></o:p></span></p>
  </td>
  <td width=96 style='width:72.0pt;border:none;border-right:solid black 1.0pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  31.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Cat XI<o:p></o:p></span></p>
  </td>
  <td width=125 style='width:94.05pt;border:none;border-right:solid black 1.0pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  31.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>30 calendar days<o:p></o:p></span></p>
  </td>
  <td width=109 style='width:81.4pt;border:none;border-right:solid black 1.0pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  31.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>30 days<o:p></o:p></span></p>
  </td>
  <td width=120 style='width:90.15pt;border:none;border-right:solid black 1.0pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  31.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>90 days<o:p></o:p></span></p>
  </td>
  <td width=177 style='width:132.75pt;border:none;border-right:solid black 1.0pt;
  mso-border-right-alt:solid black .5pt;padding:0cm 5.4pt 0cm 5.4pt;height:
  31.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>-do-<o:p></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:7;height:35.5pt'>
  <td width=64 style='width:47.65pt;border:solid windowtext 1.0pt;border-top:
  none;mso-border-left-alt:solid windowtext .5pt;mso-border-bottom-alt:solid windowtext .5pt;
  mso-border-right-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:35.5pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>3(d)<o:p></o:p></span></p>
  </td>
  <td width=96 style='width:72.0pt;border:solid windowtext 1.0pt;border-left:
  none;mso-border-top-alt:solid windowtext .5pt;mso-border-bottom-alt:solid windowtext .5pt;
  mso-border-right-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:35.5pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Cat. XII<o:p></o:p></span></p>
  </td>
  <td width=125 style='width:94.05pt;border:solid windowtext 1.0pt;border-left:
  none;mso-border-top-alt:solid windowtext .5pt;mso-border-bottom-alt:solid windowtext .5pt;
  mso-border-right-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:35.5pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>15 calendar days<o:p></o:p></span></p>
  </td>
  <td width=109 style='width:81.4pt;border:solid windowtext 1.0pt;border-left:
  none;mso-border-top-alt:solid windowtext .5pt;mso-border-bottom-alt:solid windowtext .5pt;
  mso-border-right-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:35.5pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>15 days<o:p></o:p></span></p>
  </td>
  <td width=120 style='width:90.15pt;border:solid windowtext 1.0pt;border-left:
  none;mso-border-top-alt:solid windowtext .5pt;mso-border-bottom-alt:solid windowtext .5pt;
  mso-border-right-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:35.5pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>-do-<o:p></o:p></span></p>
  </td>
  <td width=177 style='width:132.75pt;border:solid windowtext 1.0pt;border-left:
  none;mso-border-top-alt:solid windowtext .5pt;mso-border-bottom-alt:solid windowtext .5pt;
  mso-border-right-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:35.5pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>-do-<o:p></o:p></span></p>
  </td>
 </tr>
 <tr style='mso-yfti-irow:8;mso-yfti-lastrow:yes;height:60.0pt'>
  <td width=64 style='width:47.65pt;border:solid windowtext 1.0pt;border-top:
  none;mso-border-left-alt:solid windowtext .5pt;mso-border-bottom-alt:solid windowtext .5pt;
  mso-border-right-alt:solid windowtext .5pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:60.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>(e)<o:p></o:p></span></p>
  </td>
  <td width=96 style='width:72.0pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;mso-border-bottom-alt:
  solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;padding:
  0cm 5.4pt 0cm 5.4pt;height:60.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>Trainees (GET/<span style='mso-spacerun:yes'>  
  </span>DET/ ITI Trainee)<o:p></o:p></span></p>
  </td>
  <td width=125 style='width:94.05pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:60.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>15 calendar days<o:p></o:p></span></p>
  </td>
  <td width=109 style='width:81.4pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:60.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>15 days<o:p></o:p></span></p>
  </td>
  <td width=120 style='width:90.15pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:60.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>-do-<o:p></o:p></span></p>
  </td>
  <td width=177 style='width:132.75pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  mso-border-bottom-alt:solid windowtext .5pt;mso-border-right-alt:solid windowtext .5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:60.0pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
  justify;line-height:normal'><span lang=EN-US style='font-size:12.0pt;
  font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
  mso-bidi-font-family:Arial'>-do-<o:p></o:p></span></p>
  </td>
 </tr>
</table>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'>Leaves will be credited to individual account on 1st January every year.</span><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'>Site posted staff can avail 3 days Causal Leave or Privilege Leave for
availing LTA.<span style='mso-spacerun:yes'>  </span>Therefore, their carry
forward Privilege Leave is 30 days or the unused PL balance every year.<o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'>Not availed Sick Leave of Cat. XI &amp; XII can be en-cashed every year.</span><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'>As per Maternity Act, all eligible women employees are allowed 84 days
(12 weeks) Maternity Leave.</span><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'>The accumulated Sick Leave can be availed only in the case of an
employee falling sick for a longer period and exceeds his entitlement in that
particular year. This requires Business Head approval. The employee must submit
adequate proof of his illness including a Medical certificate.<o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'>If the employee does not have sufficient leave balance to regularize
their absent days, he/she can apply for Advance Privilege with approval of
Business Head. This is manual process and can be authorized by HR.<o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:27.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'>An employee availing LTA to get tax benefits will be permitted to take a
minimum 3 days continuous privilege leave. The balance 3 days privilege leave
can be taken any time during the year. But this leave may not be taken more
than 3 times a year.<o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'>Not availed LTC may be carry forward in next year subject to sanctioned
by Business Head. This is manual process and can be authorized by HR.<o:p></o:p></span></p>

<p class=MsoNormal style='mso-margin-top-alt:auto;margin-bottom:6.0pt;
text-align:justify;line-height:normal;tab-stops:72.0pt'><b style='mso-bidi-font-weight:
normal'><u><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:Arial'>Clubbing
of leaves</span></u></b><b style='mso-bidi-font-weight:normal'><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'>:<o:p></o:p></span></b></p>

<p class=MsoNormal style='mso-margin-top-alt:auto;margin-bottom:6.0pt;
text-align:justify;line-height:normal;tab-stops:72.0pt'><b style='mso-bidi-font-weight:
normal'><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:Arial'>CL+SL=
Allowed<o:p></o:p></span></b></p>

<p class=MsoNormal style='mso-margin-top-alt:auto;margin-bottom:6.0pt;
text-align:justify;line-height:normal;tab-stops:72.0pt'><b style='mso-bidi-font-weight:
normal'><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:Arial'>SL+CL=Not
Allowed<o:p></o:p></span></b></p>

<p class=MsoNormal style='mso-margin-top-alt:auto;margin-bottom:6.0pt;
text-align:justify;line-height:normal;tab-stops:72.0pt'><b style='mso-bidi-font-weight:
normal'><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:Arial'>CL+PL=Allowed<o:p></o:p></span></b></p>

<p class=MsoNormal style='mso-margin-top-alt:auto;margin-bottom:6.0pt;
text-align:justify;line-height:normal;tab-stops:72.0pt'><b style='mso-bidi-font-weight:
normal'><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:Arial'>PL+CL=Not
Allowed<o:p></o:p></span></b></p>

<p class=MsoNormal style='mso-margin-top-alt:auto;margin-bottom:6.0pt;
text-align:justify;line-height:normal;tab-stops:72.0pt'><b style='mso-bidi-font-weight:
normal'><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:Arial'>PL+SL=Allowed</span></b><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman";mso-bidi-font-family:Arial'><o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'>Employee is permitted to take Casual Leave and then Sick or Privilege
leave to avoid counting intervening holiday.<span style='mso-spacerun:yes'> 
</span><o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:list 63.0pt left 72.0pt'><span lang=EN-US style='font-size:
12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>Availing first Sick/Privilege leave and then Casual
Leave is not allowed.</span><span lang=EN-US style='font-size:12.0pt;
font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:list 63.0pt left 72.0pt'><span lang=EN-US style='font-size:
12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>If an employee is availing Privilege leave and
falls sick after that he can avail Sick leave for the period he falls sick.</span><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:list 63.0pt left 72.0pt'><span lang=EN-US style='font-size:
12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>No Medical Certificate is required for availing
Sick Leave; the leave is sanctioned at the discretion of the HOD.</span><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:list 63.0pt left 72.0pt'><span lang=EN-US style='font-size:
12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:"Times New Roman";
mso-bidi-font-family:Arial'>Intervening holiday or weekly rest holiday falling
in between casual leaves are not counted as casual leave.</span><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;
margin-left:27.0pt;text-align:justify;mso-line-height-alt:1.15pt;tab-stops:
9.0pt 72.0pt list 99.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:
Arial'>&nbsp;</span><span lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";
mso-fareast-font-family:"Times New Roman"'><o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:36.0pt'><b
style='mso-bidi-font-weight:normal'><u><span lang=EN-US style='font-size:12.0pt;
line-height:115%;font-family:"Cambria","serif"'>Site Transfer Leave = 7days<o:p></o:p></span></u></b></p>

<p class=MsoNormal style='text-align:justify;tab-stops:36.0pt'><span
lang=EN-US style='font-size:12.0pt;line-height:115%;font-family:"Cambria","serif"'>The
Employee will be entitled to 7days leave (in addition to his normal entitlement
of accrued leaves) including the travel time and any intervening holidays /
weekly off/ tour status on transfer. This transfer leave is meant to facilitate
transfer and settling down at the new place of posting. This cannot be
accumulated and availed at a later date unless the employee alone moves to the new
location initially and the family and the household goods are moved later, due
to exigencies of work or reasons personal to the employee. The leave
application must be submitted at the new location.<o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:27.0pt'><b style='mso-bidi-font-weight:normal'><u><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif";mso-fareast-font-family:
"Times New Roman"'>New <span class=SpellE>Joinees</span> leaves <o:p></o:p></span></u></b></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman"'>CL+SL will be
calculated on prorate basis from date of Joining &amp; will be credited
immediately.<o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman"'>PL + LTC will get
credited in next calendar year.<o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:6.0pt;text-align:justify;line-height:
normal;tab-stops:72.0pt'><span lang=EN-US style='font-size:12.0pt;font-family:
"Cambria","serif";mso-fareast-font-family:"Times New Roman"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:36.0pt'><b
style='mso-bidi-font-weight:normal'><u><span lang=EN-US style='font-size:12.0pt;
line-height:115%;font-family:"Cambria","serif"'>Leave &amp; Attendance rules
for Contractual staff:-<o:p></o:p></span></u></b></p>

<p class=MsoNormal style='text-align:justify;tab-stops:36.0pt'><span
lang=EN-US style='font-size:12.0pt;line-height:115%;font-family:"Cambria","serif"'>The
Contractual staff will be entitled for 2days leave every month on 1ts day.
Leave nature will be “Casual Leave”.<o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
justify;line-height:normal;tab-stops:27.0pt'><span class=SpellE><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif"'>Unavailed</span></span><span
lang=EN-US style='font-size:12.0pt;font-family:"Cambria","serif"'> leaves will
accumulate maximum 24days in a calendar year and </span><span lang=EN-US
style='font-family:"Arial","sans-serif";mso-bidi-font-family:"Times New Roman"'>will
be <span class=SpellE>encashable</span>.<o:p></o:p></span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;text-align:
justify;line-height:normal;tab-stops:27.0pt'><span lang=EN-US style='font-family:
"Arial","sans-serif";mso-bidi-font-family:"Times New Roman"'><span
style='mso-tab-count:1'>         </span><o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:36.0pt 165.75pt'><span
lang=EN-US style='font-size:12.0pt;line-height:115%;font-family:"Cambria","serif"'><span
style='mso-spacerun:yes'> </span>Intervening holiday or weekly off in between
leaves are not counted as casual leave.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:36.0pt 165.75pt'><span
lang=EN-US style='font-size:12.0pt;line-height:115%;font-family:"Cambria","serif"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:36.0pt'><span
lang=EN-US style='font-size:12.0pt;line-height:115%;font-family:"Cambria","serif"'><o:p>&nbsp;</o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:36.0pt'><span
lang=EN-US style='font-size:12.0pt;line-height:115%;font-family:"Cambria","serif"'><o:p>&nbsp;</o:p></span></p>

    </div>
  </ContentTemplate>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
