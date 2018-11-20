<script type="text/javascript"> 
var script_atnSiteAttendance = {
    ACEFinYear_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('FinYear','');
      var F_FinYear = $get(sender._element.id);
      var F_FinYear_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_FinYear.value = p[0];
      F_FinYear_Display.innerHTML = e.get_text();
    },
    ACEFinYear_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('FinYear','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEFinYear_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACECardNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CardNo','');
      var F_CardNo = $get(sender._element.id);
      var F_CardNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CardNo.value = p[0];
      F_CardNo_Display.innerHTML = e.get_text();
    },
    ACECardNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CardNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECardNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_FinYear: function(sender) {
      var Prefix = sender.id.replace('FinYear','');
      this.validated_FK_ATN_SiteAttendance_FinYear_main = true;
      this.validate_FK_ATN_SiteAttendance_FinYear(sender,Prefix);
      },
    validate_CardNo: function(sender) {
      var Prefix = sender.id.replace('CardNo','');
      this.validated_FK_ATN_SiteAttendance_CardNo_main = true;
      this.validate_FK_ATN_SiteAttendance_CardNo(sender,Prefix);
      },
    validate_FK_ATN_SiteAttendance_FinYear: function(o,Prefix) {
      var value = o.id;
      var FinYear = $get(Prefix + 'FinYear');
      if(FinYear.value==''){
        if(this.validated_FK_ATN_SiteAttendance_FinYear_main){
          var o_d = $get(Prefix + 'FinYear' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FinYear.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ATN_SiteAttendance_FinYear(value, this.validated_FK_ATN_SiteAttendance_FinYear);
      },
    validated_FK_ATN_SiteAttendance_FinYear_main: false,
    validated_FK_ATN_SiteAttendance_FinYear: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_atnSiteAttendance.validated_FK_ATN_SiteAttendance_FinYear_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_ATN_SiteAttendance_CardNo: function(o,Prefix) {
      var value = o.id;
      var CardNo = $get(Prefix + 'CardNo');
      if(CardNo.value==''){
        if(this.validated_FK_ATN_SiteAttendance_CardNo_main){
          var o_d = $get(Prefix + 'CardNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CardNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ATN_SiteAttendance_CardNo(value, this.validated_FK_ATN_SiteAttendance_CardNo);
      },
    validated_FK_ATN_SiteAttendance_CardNo_main: false,
    validated_FK_ATN_SiteAttendance_CardNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_atnSiteAttendance.validated_FK_ATN_SiteAttendance_CardNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
