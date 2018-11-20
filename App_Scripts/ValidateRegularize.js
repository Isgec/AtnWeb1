var lgValidate = {
  ldest: '',
  lpurpose: '',
  ASCanBeApplied: false,
  ADCanBeApplied: false,
  SplitClickToggleTypes: false,
  //****************************
  leavetype_click: function (o) {
    var aIDs = o.id.split('±');
    if (aIDs[1] == 'AS') {
      if (this.ASCanBeApplied == false) {
        o.checked = false;
        alert('ACCUMULATED SICK Leave can not be applied online. Mannually take approval and submit it to HR.');
        return false;
      }
    }
    if (aIDs[1] == 'AD') {
      if (this.ADCanBeApplied == false) {
        o.checked = false;
        alert('ADAVANCE PRIVILEDGE Leave can not be applied online. Mannually take approval and submit it to HR.');
        return false;
      }
    }
    var prefix = aIDs[0];
    var sufix = aIDs[aIDs.length - 1];
    var osplit = $get(prefix + '±ZZ±' + sufix);
    var oappld = $get(prefix + '±AA±' + sufix);
    var tickcnt = 0;
    var aAPLD = oappld.value.split(',');
    var earlierSelected = false;
    for (i = 0; i < aAPLD.length; i++) {
      if (aAPLD[i] == aIDs[1]) {
        if (o.checked == false) {
          aAPLD[i] = '';
          earlierSelected = true;
          break;
        }
      }
    }
    if (o.checked == false) {
      if (earlierSelected) {
        oappld.value = '';
        for (i = 0; i < aAPLD.length; i++) {
          if (aAPLD[i] != '') {
            if (oappld.value == '')
              oappld.value = aAPLD[i];
            else
              oappld.value = oappld.value + ',' + aAPLD[i];
          }
        }
      }
      return;
    }
    for (i = 0; i < aLTs.length; i++) {
      var tmp = $get(prefix + '±' + aLTs[i] + '±' + sufix);
      if (tmp.checked)
        tickcnt++;
    }
    if (tickcnt > 2) {
      o.checked = false;
      return;
    }
    if (tickcnt > 1) {
      if (osplit.checked == false) {
        o.checked = false;
        return;
      }
    }
    if (o.checked) {
      if (oappld.value == '')
        oappld.value = aIDs[1];
      else
        oappld.value = oappld.value + ',' + aIDs[1];
      if (aIDs[1] == 'OD') {
        var outer = $get('external');
        outer.style.position = 'absolute';
        outer.style.display = 'block';
        var olbl = $get(prefix + '±GG±' + sufix);
        olbl.style.position = 'absolute';
        olbl.style.display = 'block';
        var odest = $get(prefix + '±HH±' + sufix);
        if (odest.value == '')
          odest.value = this.ldest;
        var opurpose = $get(prefix + '±II±' + sufix);
        if (opurpose.value == '')
          opurpose.value = this.lpurpose;
      }
    }
  },
  //************************
  split_click: function (o) {
    var aIDs = o.id.split('±');
    var prefix = aIDs[0];
    var sufix = aIDs[aIDs.length - 1];
    if (o.checked == false) {
      for (i = 0; i < aLTs.length; i++) {
        var tmp = $get(prefix + '±' + aLTs[i] + '±' + sufix);
        tmp.checked = false;
        if (this.SplitClickToggleTypes) {
          if (aLTs[i] != 'OD')
            tmp.disabled = true;
        }
      }
      var oappld = $get(prefix + '±AA±' + sufix);
      oappld.value = '';
    } else {
      for (i = 0; i < aLTs.length; i++) {
        var tmp = $get(prefix + '±' + aLTs[i] + '±' + sufix);
        if (this.SplitClickToggleTypes) {
          if (aLTs[i] != 'OD')
            tmp.disabled = false;
        }
      }
    }
  },
  //***************************
  mouseover_date: function (o) {
    var aIDs = o.id.split('±');
    var prefix = aIDs[0];
    var sufix = aIDs[aIDs.length - 1];
    var olbl = $get(prefix + '±CC±' + sufix);
    olbl.style.position = 'absolute';
    olbl.style.display = 'block';
  },
  //**************************
  mouseout_date: function (o) {
    var aIDs = o.id.split('±');
    var prefix = aIDs[0];
    var sufix = aIDs[aIDs.length - 1];
    var olbl = $get(prefix + '±CC±' + sufix);
    olbl.style.position = '';
    olbl.style.display = 'none';
  },
  //*************************************
  showotherleavetype_click: function (o) {
    var aIDs = o.id.split('±');
    var prefix = aIDs[0];
    var sufix = aIDs[aIDs.length - 1];
    var otbl = $get(prefix + '±EE±' + sufix);
    if (otbl.style.display == 'none') {
      otbl.style.position = 'absolute';
      otbl.style.display = 'block';
    }
    else {
      otbl.style.position = '';
      otbl.style.display = 'none';
    }
  },
  //*************************************
  hideotherleavetype_click: function (o) {
    var aIDs = o.id.split('±');
    var prefix = aIDs[0];
    var sufix = aIDs[aIDs.length - 1];
    var olbl = $get(prefix + '±EE±' + sufix);
    olbl.style.position = '';
    olbl.style.display = 'none';
  },
  //*******************************
  hideODdetail_click: function (o) {
    var aIDs = o.id.split('±');
    var prefix = aIDs[0];
    var sufix = aIDs[aIDs.length - 1];
    var odest = $get(prefix + '±HH±' + sufix);
    if (odest.value == '') {
      alert('Destination must be entered.');
      odest.focus();
      return;
    }
    var opurpose = $get(prefix + '±II±' + sufix);
    if (opurpose.value == '') {
      alert('Purpose must be entered.');
      opurpose.focus();
      return;
    }
    this.ldest = odest.value;
    this.lpurpose = opurpose.value;
    var olbl = $get(prefix + '±GG±' + sufix);
    olbl.style.position = '';
    olbl.style.display = 'none';
    var outer = $get('external');
    outer.style.position = '';
    outer.style.display = 'none';
  },
  //****************************
  cmdSubmit_Click: function (o) {
    var context = '';
    var FRemarks = $get('F_Remarks');
    if (FRemarks == null) {
      FRemarks = $get('cph1_F_Remarks');
      if (FRemarks == null)
        FRemarks = $get('cph1_F_Remarks');
      var tv = $find('meetv');
      if (tv._IsValid == false)
        return;
    }
    if (FRemarks.value == '') {
      alert('Reason is required.');
      return;
    }
    else {
      FRemarks.value = FRemarks.value.replace(':', '-');
    }
    o.disabled = true;
    showProcessingMPV();
    for (i = 0; i < document.all.length; i++) {
      var el = document.all[i];
      if (el.id != null) {
        if (el.id.indexOf('±AA±') > 0) {
          if (el.value != '') {
            var ael = el.id.split('±');
            var atp = $get(ael[0] + '±YY±' + ael[ael.length - 1]);
            if (context == '') {
              context = ael[ael.length - 1] + '|' + el.value + '|' + atp.value;
            } else {
              context = context + '±' + ael[ael.length - 1] + '|' + el.value + '|' + atp.value;
            }
            if (el.value.indexOf('OD') > -1) {
              var prefix = ael[0];
              var sufix = ael[ael.length - 1];
              var odest = $get(prefix + '±HH±' + sufix);
              var opurpose = $get(prefix + '±II±' + sufix);
              context = context + '|' + odest.value + '|' + opurpose.value;
            }
          }
        }
      }
    }
    if (context != '') {
      context = context + ':' + FRemarks.value;
      PageMethods.CheckAppliedLeaves(context, this.ShowAppliedLeaveStatus);
    } else
      AppliedLeaveStatusOver('false');
  },
  //****************************************
  ShowAppliedLeaveStatus: function (result) {
    hideProcessingMPV();
    backgroundColor('silver');
    dynamicMessage(result);
    showMessageMPV();
  },
  //**************************************
  UpdateAppliedLeaves: function (context) {
    cancelMessage();
    showProcessingMPV();
    PageMethods.UpdateAppliedLeaveStatus(context, this.AppliedLeaveStatusOver);
  },
  //****************************************
  AppliedLeaveStatusOver: function (result) {
    if (result == 'true') {
      __doPostBack('', '');
      return;
    }
    var o = $get('cmdSubmit');
    o.disabled = false;
    hideProcessingMPV();
  },
  //************************************
  AppliedLeaveStatusCancel: function () {
    var o = $get('cmdSubmit');
    o.disabled = false;
  }
};
