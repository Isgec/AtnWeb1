<script type="text/javascript"> 
var script_newHrmEmployees = {
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
    ACEVerifierID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('VerifierID','');
      var F_VerifierID = $get(sender._element.id);
      var F_VerifierID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_VerifierID.value = p[0];
      F_VerifierID_Display.innerHTML = e.get_text();
    },
    ACEVerifierID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('VerifierID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEVerifierID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEApproverID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ApproverID','');
      var F_ApproverID = $get(sender._element.id);
      var F_ApproverID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ApproverID.value = p[0];
      F_ApproverID_Display.innerHTML = e.get_text();
    },
    ACEApproverID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ApproverID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEApproverID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACESiteAllowanceApprover_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SiteAllowanceApprover','');
      var F_SiteAllowanceApprover = $get(sender._element.id);
      var F_SiteAllowanceApprover_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SiteAllowanceApprover.value = p[0];
      F_SiteAllowanceApprover_Display.innerHTML = e.get_text();
    },
    ACESiteAllowanceApprover_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SiteAllowanceApprover','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESiteAllowanceApprover_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACETAVerifier_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TAVerifier','');
      var F_TAVerifier = $get(sender._element.id);
      var F_TAVerifier_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TAVerifier.value = p[0];
      F_TAVerifier_Display.innerHTML = e.get_text();
    },
    ACETAVerifier_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TAVerifier','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETAVerifier_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACETASanctioningAuthority_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TASanctioningAuthority','');
      var F_TASanctioningAuthority = $get(sender._element.id);
      var F_TASanctioningAuthority_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TASanctioningAuthority.value = p[0];
      F_TASanctioningAuthority_Display.innerHTML = e.get_text();
    },
    ACETASanctioningAuthority_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TASanctioningAuthority','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETASanctioningAuthority_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACETAApprover_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TAApprover','');
      var F_TAApprover = $get(sender._element.id);
      var F_TAApprover_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TAApprover.value = p[0];
      F_TAApprover_Display.innerHTML = e.get_text();
    },
    ACETAApprover_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TAApprover','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETAApprover_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_C_ProjectSiteID: function(sender) {
      var Prefix = sender.id.replace('C_ProjectSiteID','');
      this.validated_FK_HRM_C_ProjectSiteID_main = true;
      this.validate_FK_HRM_C_ProjectSiteID(sender,Prefix);
      },
    validate_VerifierID: function(sender) {
      var Prefix = sender.id.replace('VerifierID','');
      this.validated_FK_HRM_Employees_VerifierID_main = true;
      this.validate_FK_HRM_Employees_VerifierID(sender,Prefix);
      },
    validate_ApproverID: function(sender) {
      var Prefix = sender.id.replace('ApproverID','');
      this.validated_FK_HRM_Employees_ApproverID_main = true;
      this.validate_FK_HRM_Employees_ApproverID(sender,Prefix);
      },
    validate_SiteAllowanceApprover: function(sender) {
      var Prefix = sender.id.replace('SiteAllowanceApprover','');
      this.validated_FK_HRM_Employees_SiteAllowanceApprover_main = true;
      this.validate_FK_HRM_Employees_SiteAllowanceApprover(sender,Prefix);
      },
    validate_TAVerifier: function(sender) {
      var Prefix = sender.id.replace('TAVerifier','');
      this.validated_FK_HRM_Employees_TAVerifier_main = true;
      this.validate_FK_HRM_Employees_TAVerifier(sender,Prefix);
      },
    validate_TASanctioningAuthority: function(sender) {
      var Prefix = sender.id.replace('TASanctioningAuthority','');
      this.validated_FK_HRM_Employees_TASanctioningAuthority_main = true;
      this.validate_FK_HRM_Employees_TASanctioningAuthority(sender,Prefix);
      },
    validate_TAApprover: function(sender) {
      var Prefix = sender.id.replace('TAApprover','');
      this.validated_FK_HRM_Employees_TAApprover_main = true;
      this.validate_FK_HRM_Employees_TAApprover(sender,Prefix);
      },
    validate_FK_HRM_Employees_SiteAllowanceApprover: function(o,Prefix) {
      var value = o.id;
      var SiteAllowanceApprover = $get(Prefix + 'SiteAllowanceApprover');
      if(SiteAllowanceApprover.value==''){
        if(this.validated_FK_HRM_Employees_SiteAllowanceApprover_main){
          var o_d = $get(Prefix + 'SiteAllowanceApprover' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SiteAllowanceApprover.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Employees_SiteAllowanceApprover(value, this.validated_FK_HRM_Employees_SiteAllowanceApprover);
      },
    validated_FK_HRM_Employees_SiteAllowanceApprover_main: false,
    validated_FK_HRM_Employees_SiteAllowanceApprover: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_newHrmEmployees.validated_FK_HRM_Employees_SiteAllowanceApprover_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_HRM_Employees_VerifierID: function(o,Prefix) {
      var value = o.id;
      var VerifierID = $get(Prefix + 'VerifierID');
      if(VerifierID.value==''){
        if(this.validated_FK_HRM_Employees_VerifierID_main){
          var o_d = $get(Prefix + 'VerifierID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + VerifierID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Employees_VerifierID(value, this.validated_FK_HRM_Employees_VerifierID);
      },
    validated_FK_HRM_Employees_VerifierID_main: false,
    validated_FK_HRM_Employees_VerifierID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_newHrmEmployees.validated_FK_HRM_Employees_VerifierID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_HRM_Employees_ApproverID: function(o,Prefix) {
      var value = o.id;
      var ApproverID = $get(Prefix + 'ApproverID');
      if(ApproverID.value==''){
        if(this.validated_FK_HRM_Employees_ApproverID_main){
          var o_d = $get(Prefix + 'ApproverID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ApproverID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Employees_ApproverID(value, this.validated_FK_HRM_Employees_ApproverID);
      },
    validated_FK_HRM_Employees_ApproverID_main: false,
    validated_FK_HRM_Employees_ApproverID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_newHrmEmployees.validated_FK_HRM_Employees_ApproverID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_HRM_Employees_TAVerifier: function(o,Prefix) {
      var value = o.id;
      var TAVerifier = $get(Prefix + 'TAVerifier');
      if(TAVerifier.value==''){
        if(this.validated_FK_HRM_Employees_TAVerifier_main){
          var o_d = $get(Prefix + 'TAVerifier' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TAVerifier.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Employees_TAVerifier(value, this.validated_FK_HRM_Employees_TAVerifier);
      },
    validated_FK_HRM_Employees_TAVerifier_main: false,
    validated_FK_HRM_Employees_TAVerifier: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_newHrmEmployees.validated_FK_HRM_Employees_TAVerifier_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_HRM_Employees_TAApprover: function(o,Prefix) {
      var value = o.id;
      var TAApprover = $get(Prefix + 'TAApprover');
      if(TAApprover.value==''){
        if(this.validated_FK_HRM_Employees_TAApprover_main){
          var o_d = $get(Prefix + 'TAApprover' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TAApprover.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Employees_TAApprover(value, this.validated_FK_HRM_Employees_TAApprover);
      },
    validated_FK_HRM_Employees_TAApprover_main: false,
    validated_FK_HRM_Employees_TAApprover: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_newHrmEmployees.validated_FK_HRM_Employees_TAApprover_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_HRM_Employees_TASanctioningAuthority: function(o,Prefix) {
      var value = o.id;
      var TASanctioningAuthority = $get(Prefix + 'TASanctioningAuthority');
      if(TASanctioningAuthority.value==''){
        if(this.validated_FK_HRM_Employees_TASanctioningAuthority_main){
          var o_d = $get(Prefix + 'TASanctioningAuthority' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TASanctioningAuthority.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Employees_TASanctioningAuthority(value, this.validated_FK_HRM_Employees_TASanctioningAuthority);
      },
    validated_FK_HRM_Employees_TASanctioningAuthority_main: false,
    validated_FK_HRM_Employees_TASanctioningAuthority: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_newHrmEmployees.validated_FK_HRM_Employees_TASanctioningAuthority_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
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
      if(script_newHrmEmployees.validated_FK_HRM_C_ProjectSiteID_main){
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
