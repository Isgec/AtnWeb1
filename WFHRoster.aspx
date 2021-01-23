<%@ Page Language="VB" AutoEventWireup="false" ClientIDMode="Static" CodeFile="WFHRoster.aspx.vb" Inherits="WFHRooster" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
  <title>WFH-Roster</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <script src="App_Scripts/jquery-3.5.1.min.js"></script>
  <link href="Res/fa/css/all.min.css" rel="stylesheet" />
  <style>
    html, body {
      font-family: Tahoma;
      font-size: 16px;
    }

    p {
      margin: 2px;
      font-size: 14px;
      font-weight: bold;
    }

    .nt-container {
      position: absolute;
      top: 0px;
      right: 0px;
      bottom: 0px;
      left: 0px;
      display: flex;
      flex-direction: column;
      border-radius: 6px;
      padding: 4px;
      background-color: antiquewhite;
    }

    .nt-header {
      display: flex;
      flex-direction: row;
      justify-content: space-between;
      background-color: #5780f8;
      border-top-left-radius: inherit;
      border-top-right-radius: inherit;
      padding: 8px;
      color: white;
    }

    .nt-body {
      height: 100%;
      padding: 2px;
      overflow-y: scroll;
      overflow-x: hidden;
      scrollbar-base-color: red;
      border-bottom-left-radius: inherit;
      border-bottom-right-radius: inherit;
    }

    .nt-input-box {
      width: 100%;
      border: 1pt solid gray;
      border-radius: 4px;
      font-size: .75rem;
    }
    .nt-dropdown {
      border: 1pt solid gray;
      background-color:lightgray;
      background:lightgray;
      color:darkgray;
      border-radius: 4px;
      font-size:1rem;
      font-weight:bold;
    }


    .nt-but-danger {
      border-radius: 4px;
      border: 1pt solid #ff0000;
      background-color: crimson;
      color: white;
      font-size: 0.9rem;
    }

      .nt-but-danger:hover {
        border-radius: 4px;
        border: 1pt solid #ff0000;
        background-color: #fa7d7d;
        color: white;
      }

    .nt-but-primary {
      border-radius: 4px;
      border: 1pt solid #1f336d;
      background-color: #2f5fe9;
      color: white;
      font-size: .9rem;
    }

      .nt-but-primary:hover {
        border-radius: 4px;
        border: 1pt solid #1f336d;
        background-color: #698bed;
        color: white;
      }

    .nt-but-grey {
      border-radius: 4px;
      border: 1pt solid #b7b5b5;
      background-color: #d7d5d5;
      color: black;
      font-size: .9rem;
    }

      .nt-but-grey:hover {
        border-radius: 4px;
        border: 1pt solid #b7b5b5;
        background-color: #f2f2f2;
        color: red;
      }

    .nt-but-readmore {
      border-radius: 4px;
      border: 1pt solid #b7b5b5;
      background-color: #d7d5d5;
      color: black;
      font-weight: bold;
      font-size: .5rem;
    }

      .nt-but-readmore:hover {
        border-radius: 4px;
        border: 1pt solid #b7b5b5;
        background-color: #f2f2f2;
        color: red;
      }

    .nt-but-success {
      border-radius: 4px;
      border: 1pt solid #049317;
      background-color: #06bf1e;
      color: white;
      font-size: .9rem;
    }

      .nt-but-success:hover {
        border-radius: 4px;
        background-color: #05fa25;
        color: black;
      }

    .nt-modal-container {
      display: none;
      position: fixed;
      z-index: 1;
      left: 0;
      top: 0;
      width: 100%;
      height: 100%;
      overflow: hidden;
      background-color: rgb(0,0,0);
      background-color: rgba(0,0,0,0.4);
    }

.label {
  color: white;
  padding: 8px;
}

.success {background-color: #4CAF50;} /* Green */
.info {background-color: #2196F3;} /* Blue */
.warning {background-color: #ff9800;} /* Orange */
.danger {background-color: #f44336;} /* Red */
.other {background-color: #e7e7e7; color: black;} /* Gray */

    .rst-alert {
      width:30%;
      position:absolute;
      top:5%;
      right:2%;
      padding: 20px;
      background-color: #f44336;
      border-radius:5px;
      color: white;
      z-index:1;
      box-shadow:5px 10px 8px #888888;
    }
    .closebtn {
      margin-left: 15px;
      color: white;
      font-weight: bold;
      float: right;
      font-size: 22px;
      line-height: 20px;
      cursor: pointer;
      transition: 0.3s;
    }

    .closebtn:hover {
      color: black;
    }
    .nt-attachment {
      background-color: lightgreen;
      border-bottom-left-radius: inherit;
      border-bottom-right-radius: inherit;
      margin: 0px 0px 0px 0px;
      color: black;
    }

    .nt-attachment-link {
      margin: 2px;
      color: black;
      font-size: .75rem;
    }

    .nt-icon {
      cursor: pointer;
    }

      .nt-icon:hover {
        color: gold;
      }

    .nt-selectedfile-div {
      display: flex;
      flex-direction: column;
      justify-content: flex-start;
    }

    .nt-selectedfile-list {
      margin: 2px;
      padding: 2px;
      color: blue;
      font-size: .65rem;
    }

    .nt-err-msg {
      color: red;
      font-weight: bold;
      font-size: .75rem;
    }

    .nt-rst-row {
      display: flex;
      flex-direction: row;
      background-color: #f1f1f1;
    }
    .nt-rst-col {
      display: flex;
      flex-direction:column;
      background-color: #f1f1f1;
    }

    .rst-bcc {
      background-color: gold;
      margin: 2px;
      padding: 4px;
      text-align: center;
      line-height: 20px;
      color: black;
      border-radius: 10px;
      font-size: 0.7rem;
    }

    .rst-table {
      width: 100%;
      position: relative;
    }

      .rst-table th {
        position: -webkit-sticky;
        position: sticky;
      }

      .rst-table td {
        text-align: center;
      }

    .rst-hd {
      background-color: DodgerBlue;
      color: white;
      margin: 2px;
      text-align: center;
      line-height: 2rem;
      font-size: .8rem;
      font-weight: bold;
      border: 2px solid #f1f1f1;
    }

    .rst-td {
      background-color: #cde5fc;
      color: black;
      margin: 2px;
      text-align: center;
      line-height: 2rem;
      font-size: .8rem;
      border: 2px solid #f1f1f1;
    }

    .rst-nw {
      background-color: gold;
      color: black;
      margin: 2px;
      text-align: center;
      line-height: 2rem;
      font-size: 1rem;
      font-weight:bold;
      border: 2px solid #f1f1f1;
    }

    .rst-en {
      background-color: #b7b5b5;
      color: white;
      margin: 2px;
      text-align: center;
      line-height: 2rem;
      font-size: .8rem;
      border: 2px solid #f1f1f1;
    }

    .wfh-hd {
      color:gray;
      margin: 2px;
      text-align: center;
      line-height: 2rem;
      font-size: 0.8rem;
      vertical-align:text-bottom;
      border: 2px solid #f1f1f1;
    }
    .rst-wfh {
      color: crimson;
      margin: 2px;
      text-align: center;
      line-height: 2rem;
      font-size: 1.5rem;
      border: 2px solid #f1f1f1;
    }

    .rst-pio {
      color: #06bf1e;
      margin: 2px;
      text-align: center;
      line-height: 2rem;
      font-size: 1.5rem;
      border: 2px solid #f1f1f1;
    }
      .h-sts:hover{
        color:gold;
        opacity: 0.7;
        cursor:default;

      }
      .l-emp:hover,
      .rst-bcc:hover,
      .rst-wfh:hover,
      .rst-pio:hover {
        opacity: 0.7;
        cursor: pointer;
      }

    .l-0 {
      background-color: bisque;
      color: deeppink;
      border-radius: 4px;
    }

    .l-1 {
      background-color: aliceblue;
      color: cornflowerblue;
      border-radius: 4px;
    }

    .d-d {
      position: relative;
      display: inline-block;
    }

    .d-d-c {
      text-align:left;
      display: none;
      position: absolute;
      background-color: #f9f9f9;
      min-width: 180px;
      border-radius:5px;
      box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
      z-index: 1;
    }

    .d-d:hover .d-d-c {
      display: block;
    }

    .d-d-c span, 
    .d-d-c a {
      color: black;
      padding: 8px 16px;
      text-decoration: none;
      display: block;
      cursor:pointer;
      border-radius:inherit;
      border-left:4pt solid #f9f9f9;
    }

      .d-d-c span:hover,
      .d-d-c a:hover {
        background-color: #f1f1f1;
        border-left:4pt solid orange;
      }

    .rst-cnt {
      border-radius: 10px;
      border: 1pt solid #1f336d;
      background-color: #2f5fe9;
      color: white;
      font-size: .7rem;
      font-weight: bold;
      margin-left: 5px;
      padding: 3px;
    }
.tt {
  position: relative;
  display: inline-block;
  border-bottom: 1px dotted black;
}

.tt .ttt {
  visibility: hidden;
  width: 120px;
  background-color: black;
  color: #fff;
  text-align: center;
  border-radius: 6px;
  padding: 5px 0;
  position: absolute;
  z-index: 1;
  bottom: 110%;
  left: 50%;
  margin-left: -60px;
}

.tt .ttt::after {
  content: "";
  position: absolute;
  top: 100%;
  left: 50%;
  margin-left: -5px;
  border-width: 5px;
  border-style: solid;
  border-color: black transparent transparent transparent;
}

.tt:hover .ttt {
  visibility: visible;
}
  </style>
</head>
<body>
  <form id="frmMain" runat="server">
    <div class="nt-container">
      <%--Header--%>
      <div class="nt-header">
        <div class="d-d">
          <div>
            <i class="fas fa-bars" style="font-size: 30px; font-weight: bold;cursor:pointer;"></i>
          </div>
          <div class="d-d-c">
            <span onclick="window.history.back();"><i class="fas fa-arrow-alt-circle-left" style="color:#2196F3;"></i>&nbsp;&nbsp;Back</span>
            <span onclick="wfh_script.loadEmp();"><i class="fas fa-retweet" style="color:#4CAF50;"></i>&nbsp;&nbsp;Refresh</span>
            <span id="cmdGenerate" runat="server" title="Generate Rooster for selected period." onclick="wfh_script.gr();"><i class="fas fa-calendar-plus" style="color:#ff9800;"></i>&nbsp;&nbsp;Generate Roster</span>
            <span id="cmdDelete" runat="server" title="Delete Rooster for selected period." onclick="wfh_script.dr();"><i class="far fa-calendar-times" style="color:#f44336;"></i>&nbsp;&nbsp;Delete Roster</span>
            <asp:LinkButton id="cmdDownload" runat="server"><i class="fas fa-download" style="color:#4CAF50;"></i>&nbsp;&nbsp;Download</asp:LinkButton>
            <span onclick="wfh_script.chooseFile();"><i class="fas fa-upload" style="color:#2196F3;"></i>&nbsp;&nbsp;Upload</span>
            <span id="cmdSetting" runat="server" title="Configuration Settings" onclick="wfh_script.setting();"><i class="fas fa-dharmachakra" style="color:gray;"></i>&nbsp;&nbsp;Setting</span>
          </div>
        </div>
        <div>
          <asp:DropDownList 
            ID = "DDLWFHConfig"
            DataSourceID = "OdsDdlWFHConfig"
            AutoPostBack="false"
            AppendDataBoundItems = "true"
            DataTextField="DisplayField"
            DataValueField="SerialNo"
            onchange="wfh_script.loadEmp();"
            Width = "200px"
            class="nt-dropdown"
            Runat="server" />
          <asp:ObjectDataSource 
            ID = "OdsDdlWFHConfig"
            TypeName = "SIS.ATN.WFHConfig"
            SortParameterName = "OrderBy"
            SelectMethod = "WFHConfigSelectList"
            Runat="server" />
        </div>
        <div>
          <span style="font-size: 25px; font-weight: bold;">WFH Roster</span>
        </div>
      </div>
      <%--Body--%>
      <div class="rst-alert" style="display:none;">
        <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span> 
        <div id="dmsError"></div>
      </div>
      <div class="nt-rst-row" id="rstBC">
        <%--Breadcrums--%>
      </div>
      <div class="nt-body">
        <div class="nt-error" id="divError" style="display: none;">
        </div>
        <style>
          .nt-stsHist {
            border: 1pt solid #b7b5b5;
            border-radius: 6px;
            background-color: #dddbdb;
            margin:10% auto;
            padding: 10px;
            width:40%;
          }
          .nt-hst-row {
            display:flex;
            justify-content:space-around;
            margin:0px;
            border-top-left-radius:inherit;
            border-top-right-radius:inherit;
            background-color:#265b85;
          }
          .nt-hst-row > div {
            margin:10px;
            font-weight:bold;
            font-size:0.8rem;
            color:white;
          }
          .nt-hst-data {
            display:flex;
            justify-content:space-between;
          }
          .nt-hst-data > div {
            margin:6px;
            font-size:0.7rem;
          }

        </style>
        <%--History data Modal Popup--%>
        <div id="divHist" class="nt-modal-container">
          <div  class="nt-stsHist">
            <%--Employee and date--%>
            <div class="nt-hst-row" id="stsHEmp">
            </div>
            <div style="font-size: 14px; font-weight: bold; margin: 6px;">
               STATUS Update History
            </div>
            <%--History Data--%>
            <div id="stsHData">
            </div>
            <div>
              <input type="button" class="nt-but-success" onclick="return wfh_script.hideHist();" value="Close" />
            </div>
          </div>

        </div>
        <%--End History data--%>

        <div class="nt-rst-row" id="rstTable">
          <%--Data--%>
        </div>
      </div>
      <div id="rst__Data" runat="server">
      </div>
    </div>
    <div id="dmsAlert" style="position: absolute; top: 50%; left: 50%; display: none; padding: 20px; border: 1pt solid black; background-color: lightgray; border-radius: 30px; box-shadow: 10px 10px 10px 10px darkgray; color: black; font-weight: bold; font-size: 14px; transform: translateY(-50%); transform: translateX(-50%);">
    </div>
    <div style="display:none;">
      <input type="file" id="f_Uploads" runat="server" onchange="return $('#cmdUpload').click();">
      <asp:Button ID="cmdUpload" runat="server" OnClientClick="return wfh_script.Loading(true);" Text="Upload" />
    </div>
  </form>
  <script>
    function $get(id) {
      return document.getElementById(id);
    }
    function BC(o) {
      this.lvl = o.lvl;
      this.enm = o.enm;
      this.cno = o.cno;
    }
    var wfh_script = {
      RstData: '',
      failed: function (z) {
        this.Loading(false);
        if (z != '') {
          $get('dmsError').innerHTML = z;
          $get("dmsError").parentElement.style.display = 'block';
        }
      },
      showAlert: function (z) {
        this.Loading(false);
        if (z != '') {
          $get('dmsAlert').innerHTML = z;
          $("#dmsAlert").show().delay(1000).fadeOut().delay(3000);
        }
      },
      Loading: function (x) {
        if (x) $get('divLoading').style.display = 'block';
        else $get('divLoading').style.display = 'none';
      },
      aBC: [],
      RenderBC: function () {
        var sRst = '';
        for (var i = 0, b; b = this.aBC[i]; i++) {
          sRst += '<div class=\'rst-bcc\' id=\'e_' + b.cno + '_' + b.lvl + '\'>';
          sRst += b.enm;
          sRst += '</div>';
        }
        $get('rstBC').innerHTML = sRst;
      },
      Render: function (oRst) {
        if (oRst.emp!=null) {
          //Render start
          var bc = new BC(oRst.emp);
          var found = false;
          var foundAt = -1;
          if (this.aBC.length > 0) {
            for (var i = 0; i < this.aBC.length; i++) {
              if (this.aBC[i].lvl == bc.lvl) {
                found = true;
                foundAt = i;
                break;
              }
            }
          }
          if (found) {
            this.aBC[foundAt] = bc;
            this.aBC.length = foundAt + 1;
          } else {
            this.aBC[this.aBC.length] = bc;
          }
          this.RenderBC();
          //
          var sRst = '';
          sRst += '<table class=\'rst-table\'>';
          sRst += '<thead>';
          sRst += this.getHeader(oRst.emp);
          sRst += '</thead>';
          sRst += '<tbody>';
          sRst += this.getRow(oRst.emp, true);
          if (typeof oRst.emp.cEmps != 'undefined') {
            for (var i = 0; i < oRst.emp.cEmps.length; i++) {
              sRst += this.getRow(oRst.emp.cEmps[i], false);
            }
          }
          sRst += '</tbody>';
          sRst += '</table>';
          $get('rstTable').innerHTML = sRst;
          //Render end
        }
        this.initialize();
      },
      getCnt: function (x) {
        if (x == 0)
          return '';
        var r = '';
        r = '<span class=\'rst-cnt\' style=\'cursor:default;\'>' + x + '</span>';
        return r;
      },
      getRow: function (x, y) {
        var z = '';
        z += '<tr>';
        z += '  <td class=\'rst-td\'>' + x.cno + '</td>';
        z += '  <td>';
        if (y) {
          z += '  <div class=\'l-1\' ';
        } else {
          z += '  <div class=\'l-0\' ';
        }
        z += '   style=\'text-align:left;\'>';
        z += '   <div><span style=\'font-size:0.6rem;color:gray;\' id=\'h_'+x.cno+'\'>' + x.rsnm + ': ' + x.h + '</span></div>';
        z += '   <div class=\'l-emp\' id=\'e_' + x.cno + '_' + x.lvl + '\' style=\'font-size:0.8rem;padding:3px;\'>' + x.enm + this.getCnt(x.c) + '</div> ';
        z += '   <div>' + x.dep + '</div>';
        z += '  </div>';
        z += '  </td>';
        for (var i = 0; i < x.rsts.length; i++) {
          var r = x.rsts[i];
          if (r.en) {
            z += '  <td class=\'rst-en\' title=\'Employee not available\'>-</td>';
          } else {
            if (r.nw) {
              z += '  <td class=\'rst-nw\' title=\'Weekly off\'>WO</td>';
            } else {
              if (r.wd) {
                z += '  <td><div class=\'tt\'><i id=\'' + r.adt + '_' + x.cno + '\' class=\'fas fa-home rst-wfh c-sts\'></i>'
                        + '<i id=\'hd_' + r.adt + '_' + x.cno + '\' class=\'fas fa-angle-down wfh-hd h-sts\'></i>'
                        + '<span id=\'ttt_' + r.adt + '_' + x.cno + '\' class=\'ttt\'>' + (r.hst.length > 0 ? r.hst[0].h : 'N/A')
                        + '</span></div></td>';
              } else {
                z += '  <td><div class=\'tt\'><i id=\'' + r.adt + '_' + x.cno + '\' class=\'fas fa-industry rst-pio c-sts\'></i>'
                        + '<i id=\'hd_' + r.adt + '_' + x.cno + '\' class=\'fas fa-angle-down wfh-hd h-sts\'></i>'
                        + '<span id=\'ttt_' + r.adt + '_' + x.cno + '\' class=\'ttt\'>' + (r.hst.length > 0 ? r.hst[0].h : 'N/A')
                        + '</span></div></td>';
              }
            }
          }
        }
        z += '</tr>';
        return z;
      },
      getHeader: function (x) {
        var z = '';
        z += '<tr>';
        z += '  <th class=\'rst-hd\'>Card No</th>';
        z += '  <th class=\'rst-hd\'>Employee</th>';
        for (var i = 0; i < x.rsts.length; i++) {
          z += '  <th class=\'rst-hd\'>' + x.rsts[i].adt.substring(0, 5) + '</th>';
        }
        z += '</tr>';
        return z;
      },
      site: '/AtnWeb1/',
      url: function () {
        return this.site + 'App_Services/WfhService.asmx/';
      },
      lastClass:'',
      changeStatus: function (x) {
        var id = x.target.id;
        var that = wfh_script;
        if ($(x.target).hasClass('fa-home')) {
          $(x.target).removeClass('fa-home');
          wfh_script.lastClass = 'fa-home';
        } else {
          $(x.target).removeClass('fa-industry');
          wfh_script.lastClass = 'fa-industry';
        }
        $(x.target).addClass('fa-sync-alt');
        $(x.target).addClass('fa-spin');
        $.ajax({
          type: 'POST',
          url: that.url() + 'ChangeStatus',
          context: that,
          dataType: 'json',
          cache: false,
          data: "{context:'" + id + "'}",
          contentType: "application/json; charset=utf-8"
        }).done(function (data, status, xhr) {
          var y = JSON.parse(data.d);
          if (y.err) {
            var t = $get(y.id);
            $(t).removeClass('fa-sync-alt');
            $(t).removeClass('fa-spin');
            $(t).addClass(wfh_script.lastClass);
            this.failed(y.msg)
          } else {
            var t = $get(y.id);
            $(t).removeClass('fa-sync-alt');
            $(t).removeClass('fa-spin');
            $(t).removeClass('rst-wfh');
            $(t).removeClass('rst-pio');
            if (!y.s) {
              $(t).addClass('rst-pio');
              $(t).addClass('fa-industry');
            } else {
              $(t).addClass('rst-wfh');
              $(t).addClass('fa-home');
            }
            $get('h_' + y.cno).innerHTML = y.rsnm+': '+y.h;
            $get('ttt_' + y.id).innerHTML = y.h;
            this.showAlert(y.msg);
          }
        }).fail(function (xhr, status, err) {
          this.failed(err);
        });

      },
      loadEmp: function (x) {
          $get('rstTable').innerHTML = '';
        var id = '';
        if (typeof x != 'undefined') {
          id = x.target.id;
        }
        id += '_' + $get('DDLWFHConfig').value;
        var that = wfh_script;
        wfh_script.Loading(true);
        $.ajax({
          type: 'POST',
          url: that.url() + 'LoadEmp',
          context: that,
          dataType: 'json',
          cache: false,
          data: "{context:'" + id + "'}",
          contentType: "application/json; charset=utf-8"
        }).done(function (data, status, xhr) {
          var m = 0;
          var y = JSON.parse(data.d);
          if (y.err) {
            this.failed(y.msg)
          } else {
            this.Render(y);
          }
          this.Loading(false);
        }).fail(function (xhr, status, err) {
          this.failed(err);
        });

      },
      gr: function () {
        if (!confirm('Generate Roster ?')) return false;
        wfh_script.Loading(true);
        var id = $get('DDLWFHConfig').value;
        var that = wfh_script;
        $.ajax({
          type: 'POST',
          url: that.url() + 'GenerateRooster',
          context: that,
          dataType: 'json',
          cache: false,
          data: "{context:'" + id + "'}",
          contentType: "application/json; charset=utf-8"
        }).done(function (data, status, xhr) {
          var y = JSON.parse(data.d);
          if (y.err) {
            this.failed(y.msg)
          } else {
            this.showAlert(y.msg);
            this.loadEmp();
          }
        }).fail(function (xhr, status, err) {
          this.failed(err);
        });
      },
      dr: function () {
        if (!confirm('Delete Roster ?')) return false;
        wfh_script.Loading(true);
        var id = $get('DDLWFHConfig').value;
        var that = wfh_script;
        $.ajax({
          type: 'POST',
          url: that.url() + 'DeleteRooster',
          context: that,
          dataType: 'json',
          cache: false,
          data: "{context:'" + id + "'}",
          contentType: "application/json; charset=utf-8"
        }).done(function (data, status, xhr) {
          var y = JSON.parse(data.d);
          if (y.err) {
            this.failed(y.msg)
          } else {
            this.showAlert(y.msg);
            this.loadEmp();
          }
        }).fail(function (xhr, status, err) {
          this.failed(err);
        });
      },
      setting: function () {
        this.failed('Contact system administrator.')
      },
      chooseFile:function() {
        $get('f_Uploads').click();
        return false;
      },
      loadHist: function (x) {
        var id = '';
        if (typeof x != 'undefined') {
          id = x.target.id;
        }
        var that = wfh_script;
        wfh_script.Loading(true);
        $.ajax({
          type: 'POST',
          url: that.url() + 'LoadHist',
          context: that,
          dataType: 'json',
          cache: false,
          data: "{context:'" + id + "'}",
          contentType: "application/json; charset=utf-8"
        }).done(function (data, status, xhr) {
          var m = 0;
          var y = JSON.parse(data.d);
          if (y.err) {
            this.failed(y.msg)
          } else {
            this.showHist(y);
          }
          this.Loading(false);
        }).fail(function (xhr, status, err) {
          this.failed(err);
        });
      },
      showHist:function(x){
        $get('divHist').style.display = 'block';
        $get('stsHEmp').innerHTML =
                                     '<div>' + x.hst.cno + '</div>'
                                   + '<div>' + x.hst.cnm + '</div>'
                                   + '<div>' + x.hst.cdt + '</div>';
        var s = '';
        for (var i = 0; i < x.hst.hist.length; i++) {
          s += '<div class=\'nt-hst-data\'>'
              + '<div>' + x.hst.hist[i].cno + '</div>'
              + '<div>' + x.hst.hist[i].cnm + '</div>'
              + '<div>' + x.hst.hist[i].cdt + '</div>'
              + '<div>' + (x.hst.hist[i].sts == true ? 'WFH' : 'WFO') + '</div>'
              + '</div>';
        }
        $get('stsHData').innerHTML = s;

        return false;
      },
      hideHist: function () {
        $get('divHist').style.display = 'none';
        return false;
      },

      initialize: function () {
        //1.
        var elm = document.getElementsByClassName('c-sts');
        for (var i = 0; i < elm.length; i++) {
          elm[i].addEventListener('click', wfh_script.changeStatus, false);
        }
        elm = document.getElementsByClassName('l-emp');
        for (var i = 0; i < elm.length; i++) {
          elm[i].addEventListener('click', wfh_script.loadEmp, false);
        }
        elm = document.getElementsByClassName('rst-bcc');
        for (var i = 0; i < elm.length; i++) {
          elm[i].addEventListener('click', wfh_script.loadEmp, false);
        }
        elm = document.getElementsByClassName('h-sts');
        for (var i = 0; i < elm.length; i++) {
          elm[i].addEventListener('click', wfh_script.loadHist, false);
        }
      }
    }
  </script>
  <div id="afterLoad" runat="server">
  </div>
  <div id="divLoading" class="nt-modal-container">
    <div style="position: absolute; top: 50%; left: 50%; transform: translateY(-50%); transform: translateX(-50%);">
      <input type="image" alt="Loading" src="Images/Loading-5.gif" style="height: 150px; width: 150px;" />
    </div>
  </div>
  <script>
   window.history.replaceState('', '', window.location.href);
    wfh_script.loadEmp();
  </script>
</body>
</html>
