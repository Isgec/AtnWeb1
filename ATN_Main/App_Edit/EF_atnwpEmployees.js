<script type="text/javascript"> 
var script_atnwpEmployees = {
    ACEC_ProjectSiteID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('C_ProjectSiteID','');
      var F_C_ProjectSiteID = $get(sender._element.id);
      var F_C_ProjectSiteID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_C_ProjectSiteID.value = p[0];
      F_C_ProjectSiteID_Display.innerHTML = e.get_text();
    },
    ACEC_ProjectSiteID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('C_ProjectSiteID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEC_ProjectSiteID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_C_ProjectSiteID: function(sender) {
      var Prefix = sender.id.replace('C_ProjectSiteID','');
      this.validated_FK_HRM_C_ProjectSiteID_main = true;
      this.validate_FK_HRM_C_ProjectSiteID(sender,Prefix);
      },
    validate_FK_HRM_C_ProjectSiteID: function(o,Prefix) {
      var value = o.id;
      var C_ProjectSiteID = $get(Prefix + 'C_ProjectSiteID');
      if(C_ProjectSiteID.value==''){
        if(this.validated_FK_HRM_C_ProjectSiteID_main){
          var o_d = $get(Prefix + 'C_ProjectSiteID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + C_ProjectSiteID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_C_ProjectSiteID(value, this.validated_FK_HRM_C_ProjectSiteID);
      },
    validated_FK_HRM_C_ProjectSiteID_main: false,
    validated_FK_HRM_C_ProjectSiteID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_atnwpEmployees.validated_FK_HRM_C_ProjectSiteID_main){
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
