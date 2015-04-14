<%@ Page Title="<%$Resources:PFSalesResource,ActCallendar %>" Language="C#" MasterPageFile="~/PFSalesMaster.master"
    AutoEventWireup="true" CodeFile="ActivityCall.aspx.cs" Inherits="ActivityCall" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script language="javascript" type="text/javascript">
        function checkvalidtime(source, args) {
            args.IsValid = true;
            var startdate = document.getElementById("ctl00_ContentPlaceHolder1_UC_AddActivity1_txtActDate");
            var enddate = document.getElementById("ctl00_ContentPlaceHolder1_UC_AddActivity1_txtEndDate");
            if (startdate.value != '' && enddate.value != '') {
                var ConvertedStDate = Date.parse(startdate.value); //convertDateTime(startdate.value);
                var ConvertedEdDate = Date.parse(enddate.value); //convertDateTime(enddate.value);
                if (ConvertedStDate == ConvertedEdDate) {
                    var starttime = document.getElementById("ctl00_ContentPlaceHolder1_UC_AddActivity1_txtActTime");
                    var endtime = document.getElementById("ctl00_ContentPlaceHolder1_UC_AddActivity1_txtEndTime");
                    if (starttime.value != '' && endtime.value != '') {
                        var strtHrs = convertHr(starttime.value);
                        var strtmin = convertMin(starttime.value);
                        var EndHrs = convertHr(endtime.value);
                        var EndMin = convertMin(endtime.value);
                        if (strtHrs == EndHrs) {
                            if (strtmin > EndMin) {
                                args.IsValid = false;
                            }
                            else if (strtmin < EndMin) {
                                args.IsValid = true;
                            }
                            else {
                                args.IsValid = true;
                            }
                        }
                        else if (strtHrs > EndHrs) {
                            args.IsValid = false;
                        }
                        else {
                            args.IsValid = true;
                        }
                    }
                }
                else if (ConvertedStDate >= ConvertedEdDate) {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }
            }
            return;
        }

        function convertDateTime(dateTime) {
            //alert(dateTime);
            var date = dateTime.split("/");
            var dd = date[0];
            var mm = date[1] - 1;
            var yyyy = date[2];
            var h = 00;
            var m = 00;
            var s = 00; //get rid of that 00.0;
            return new Date(yyyy, mm, dd, h, m, s);
        }

        function convertHr(time) {
            var newTime = time.split(":");
            var inthr = newTime[0];
            return parseInt(inthr, 10);
        }

        function convertMin(time) {
            var newTime = time.split(":");
            var intmin = newTime[1];
            return parseInt(intmin, 10);
        }

        function GetOnClientClickFunc() {
            var hdfIsAlarmNeeded = document.getElementById("ctl00_ContentPlaceHolder1_UC_AddActivity1_hdfIsAlarmNeeded");
            if (hdfIsAlarmNeeded.value == 0)
                return TestCheckBox();
            else
                return TestSecCheckBox();
        }

        function TestCheckBox() {
            var TargetChildControl = "chkSelect";
            var Inputs = (document.getElementById("ctl00_ContentPlaceHolder1_UC_AddActivity1_gvAllocate")).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.match('chkSelect') &&
            Inputs[n].checked) {
                    Count = Count + 1;
                }
            }
            if (Count == 0) {
                alert('Please Select At least One Consultant!');
                return false;
            }
            else {
                return true;
            }
        }

        function TestSecCheckBox() {
            var TargetChildControl = "chkSelect";
            var Inputs = (document.getElementById("ctl00_ContentPlaceHolder1_UC_AddActivity1_gvAllocate")).getElementsByTagName("input");
            var Count = 0;
            var totlead = 0;
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.match('chkSelect') &&
            Inputs[n].checked) {
                    Count = Count + 1;
                }
            }
            if (Count == 0) {
                alert('Please Select At least One Consultant!');
                return false;
            }
            else {
                //        chkSMS.checked == false &&        var chkSMS = document.getElementById("ctl00_ContentPlaceHolder1_UC_AddActivity1_chkSms");
                var chkEmail = document.getElementById("ctl00_ContentPlaceHolder1_UC_AddActivity1_chkEmail");
                var chkDashboard = document.getElementById("ctl00_ContentPlaceHolder1_UC_AddActivity1_chkDashBoard");
                if (chkEmail.checked == false && chkDashboard.checked == false) {
                    alert('Please Select At least One Alert Type!');
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpActCallendar" runat="server">
        <ContentTemplate>
            <div class="innerHeader">
                <img src="images/Bullate.jpg" alt="icon Img" />
                <asp:Label ID="ActCallendarHead" runat="server" Text="<%$Resources:PFSalesResource,ActCallendar %>"></asp:Label>
            </div>
            <div style="float: left; width: 100%;">
                <div style="float: left; width: 18%;">
                    <asp:Panel ID="pnlCallendar" runat="server" ForeColor="MistyRose">
                        <div class="dilContener" style="margin-left: 0px; margin-right: 0px">
                            <dl id="DlSearch" class="dealerRagisterThree" runat="server" visible="false">
                                <dt style="width: 110px;">
                                    <asp:Label ID="lblSelectConsult" runat="server" Text="<%$Resources:PFSalesResource,SelectConsultant %>"></asp:Label>
                                </dt>
                                <dd style="margin-top: -18px;">
                                    <asp:DropDownList ID="ddlConsultant" AutoPostBack="true" Width="150px" OnSelectedIndexChanged="ddlConsultant_SelectedIndexChanged"
                                        CssClass="selectClass" runat="server">
                                        <asp:ListItem Value="0" Text="<%$Resources:PFSalesResource,ddlSelect %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </dd>
                                <dt>
                                    <div class="button" style="margin-top: -5px; margin-left: 10px; width: 170px;">
                                        <asp:LinkButton ID="lnkbtnSearch" runat="server" Text="<%$Resources:PFSalesResource,Search %>"
                                            ToolTip="<%$Resources:PFSalesResource,Search %>" CausesValidation="false" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnClear" runat="server" Text="<%$Resources:PFSalesResource,Clear %>"
                                            ToolTip="<%$Resources:PFSalesResource,Clear %>" CausesValidation="false" OnClick="lnkbtnClear_Click"></asp:LinkButton>
                                    </div>
                                </dt>
                                <dd>
                                </dd>
                            </dl>
                            <asp:Calendar ID="calActivity" runat="server" Style="margin-left: 12px" Font-Bold="false"
                                BorderColor="#5b8bc9" BorderWidth="1px" BorderStyle="Solid" Height="150px" SelectionMode="Day"
                                DayNameFormat="FirstTwoLetters" OnSelectionChanged="calActivity_SelectionChanged"
                                NextMonthText='<img src ="images/nextCalendarImg.png" />' PrevMonthText='<img src ="images/previousCalendarImg.png" />'
                                Width="150" OnDayRender="calActivity_DayRender" BackColor="White" TitleStyle-BackColor="White"
                                Font-Size="11px">
                                <TodayDayStyle ForeColor="#367cad" BackColor="#fffbde" BorderColor=" #41aeda" BorderWidth="1px">
                                </TodayDayStyle>
                            </asp:Calendar>
                        </div>
                    </asp:Panel>
                </div>
                <div style="float: left; width: 82%;">
                    <asp:Panel ID="pnlCallDetails" runat="server" Visible="true">
                        <div class="dilContener" style="margin-left: 0px; margin-right: 0px">
                            <dl class="dealerRagisterThree" runat="server" visible="false">
                                <dt>
                                    <asp:Label ID="lblltrSelectedDate" runat="server" Visible="false" Text="<%$Resources:PFSalesResource,SelecteDate %>"></asp:Label>
                                </dt>
                                <dd>
                                    <asp:Label ID="lblSelectedDate" runat="server" Visible="false"></asp:Label>
                                </dd>
                                <dt>
                                    <div class="button" style="margin-top: -5px;">
                                        <asp:LinkButton ID="lnkbtnBack" runat="server" Visible="false" Text="<%$Resources:PFSalesResource,Back %>"
                                            ToolTip="<%$Resources:PFSalesResource,Back %>" CausesValidation="false" OnClick="lnkbtnBack_Click"></asp:LinkButton>
                                    </div>
                                </dt>
                                <dd>
                                </dd>
                            </dl>
                            <DayPilot:DayPilotCalendar ID="DayPilotCalendar1" runat="server" DataTextField="name"
                                DataValueField="id" Width="110%" TimeFormat="Clock12Hours" DataStartField="Start"
                                DataEndField="End" Days="5" NonBusinessHours="Show" EventClickHandling="PostBack"
                                OnEventClick="DayPilotCalendar1_OnEventClick" EventRightClickEnabled="true" OnBeforeEventRender="DayPilotCalendar1_BeforeEventRender"
                                TimeRangeSelectedHandling="PostBack"></DayPilot:DayPilotCalendar>
                            <%--OnTimeRangeSelected="DayPilotCalendar1_TimeRangeSelected"--%>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <asp:Panel ID="pnlAddAct" runat="server" Visible="false">
                <div class="pop-up">
                </div>
                <div class="contentPopUp" style="height: 580px; margin-left: -75%; top: 10px; width: 520px;
                    overflow-y: scroll;">
                    <div class="popHeader">
                        <asp:Label ID="lblAddActPopUp" runat="server" Text="<%$ Resources:PFSalesResource,AddNewActivity%>"></asp:Label>
                        <asp:LinkButton ID="lnkbtnAddActPopUpClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                            OnClick="lnkbtnAddActPopUpClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                    </div>
                    <div class="dilContenerTwo" style="float: left; margin-bottom: 20px; margin-left: 15px;
                        margin-right: 25px; margin-top: 5px;">
                    </div>
                    <%--<uc1:UC_AddActivity ID="UC_AddActivity1" runat="server" />--%>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlClearActDeatils" runat="server" Visible="false">
                <div class="pop-up" style="z-index: 10025;">
                </div>
                <div class="contentPopUp" style="margin-left: -75%; top: 12px; width: 505px; z-index: 10030;">
                    <div class="popHeader">
                        <asp:Label ID="lblClearActDetHead" runat="server" Text="<%$ Resources:PFSalesResource,ClearActDet%>"></asp:Label>
                        <asp:LinkButton ID="lnkbtnClearActDetClose" runat="server" ToolTip="<%$ Resources:PFSalesResource,Close %>"
                            OnClick="lnkbtnClearActDetClose_Click"><img src="Images/delete.png" style="padding-top:7px; padding-right:12px;"/></asp:LinkButton>
                    </div>
                    <%--<uc4:UC_ClearActivityDetails ID="UC_ClearActivityDetails1" runat="server" />--%>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upproProsp" runat="server" DisplayAfter="500" AssociatedUpdatePanelID="UpActCallendar">
        <ProgressTemplate>
            <div id="progressBackgroundFilter">
            </div>
            <div id="processMessage">
                <span style="text-align: center;">
                    <img src="Images/loading.gif" />
                    <br />
                    <asp:Literal ID="ltrwait" runat="server" Text="<%$Resources:PFSalesResource,PleaseWait %>"></asp:Literal>
                </span>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
