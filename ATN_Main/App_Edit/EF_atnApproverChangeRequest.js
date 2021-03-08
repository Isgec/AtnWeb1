<script type="text/javascript"> 
var script_atnApproverChangeRequest = {
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
    ACETAVerifierID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TAVerifierID','');
      var F_TAVerifierID = $get(sender._element.id);
      var F_TAVerifierID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TAVerifierID.value = p[0];
      F_TAVerifierID_Display.innerHTML = e.get_text();
    },
    ACETAVerifierID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TAVerifierID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETAVerifierID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACETAApproverID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TAApproverID','');
      var F_TAApproverID = $get(sender._element.id);
      var F_TAApproverID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TAApproverID.value = p[0];
      F_TAApproverID_Display.innerHTML = e.get_text();
    },
    ACETAApproverID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TAApproverID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETAApproverID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACETASA_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TASA','');
      var F_TASA = $get(sender._element.id);
      var F_TASA_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TASA.value = p[0];
      F_TASA_Display.innerHTML = e.get_text();
    },
    ACETASA_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TASA','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETASA_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_VerifierID: function(sender) {
      var Prefix = sender.id.replace('VerifierID','');
      this.validated_FK_ATN_ApproverChangeRequest_VerifierID_main = true;
      this.validate_FK_ATN_ApproverChangeRequest_VerifierID(sender,Prefix);
      },
    validate_ApproverID: function(sender) {
      var Prefix = sender.id.replace('ApproverID','');
      this.validated_FK_ATN_ApproverChangeRequest_AppriverID_main = true;
      this.validate_FK_ATN_ApproverChangeRequest_AppriverID(sender,Prefix);
      },
    validate_TAVerifierID: function(sender) {
      var Prefix = sender.id.replace('TAVerifierID','');
      this.validated_FK_ATN_ApproverChangeRequest_TAVerifierID_main = true;
      this.validate_FK_ATN_ApproverChangeRequest_TAVerifierID(sender,Prefix);
      },
    validate_TAApproverID: function(sender) {
      var Prefix = sender.id.replace('TAApproverID','');
      this.validated_FK_ATN_ApproverChangeRequest_TAApproverID_main = true;
      this.validate_FK_ATN_ApproverChangeRequest_TAApproverID(sender,Prefix);
      },
    validate_TASA: function(sender) {
      var Prefix = sender.id.replace('TASA','');
      this.validated_FK_ATN_ApproverChangeRequest_TASA_main = true;
      this.validate_FK_ATN_ApproverChangeRequest_TASA(sender,Prefix);
      },
    validate_FK_ATN_ApproverChangeRequest_VerifierID: function(o,Prefix) {
      var value = o.id;
      var VerifierID = $get(Prefix + 'VerifierID');
      if(VerifierID.value==''){
        if(this.validated_FK_ATN_ApproverChangeRequest_VerifierID_main){
          var o_d = $get(Prefix + 'VerifierID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + VerifierID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ATN_ApproverChangeRequest_VerifierID(value, this.validated_FK_ATN_ApproverChangeRequest_VerifierID);
      },
    validated_FK_ATN_ApproverChangeRequest_VerifierID_main: false,
    validated_FK_ATN_ApproverChangeRequest_VerifierID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_atnApproverChangeRequest.validated_FK_ATN_ApproverChangeRequest_VerifierID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_ATN_ApproverChangeRequest_AppriverID: function(o,Prefix) {
      var value = o.id;
      var ApproverID = $get(Prefix + 'ApproverID');
      if(ApproverID.value==''){
        if(this.validated_FK_ATN_ApproverChangeRequest_AppriverID_main){
          var o_d = $get(Prefix + 'ApproverID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ApproverID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ATN_ApproverChangeRequest_AppriverID(value, this.validated_FK_ATN_ApproverChangeRequest_AppriverID);
      },
    validated_FK_ATN_ApproverChangeRequest_AppriverID_main: false,
    validated_FK_ATN_ApproverChangeRequest_AppriverID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_atnApproverChangeRequest.validated_FK_ATN_ApproverChangeRequest_AppriverID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_ATN_ApproverChangeRequest_TAVerifierID: function(o,Prefix) {
      var value = o.id;
      var TAVerifierID = $get(Prefix + 'TAVerifierID');
      if(TAVerifierID.value==''){
        if(this.validated_FK_ATN_ApproverChangeRequest_TAVerifierID_main){
          var o_d = $get(Prefix + 'TAVerifierID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TAVerifierID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ATN_ApproverChangeRequest_TAVerifierID(value, this.validated_FK_ATN_ApproverChangeRequest_TAVerifierID);
      },
    validated_FK_ATN_ApproverChangeRequest_TAVerifierID_main: false,
    validated_FK_ATN_ApproverChangeRequest_TAVerifierID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_atnApproverChangeRequest.validated_FK_ATN_ApproverChangeRequest_TAVerifierID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_ATN_ApproverChangeRequest_TAApproverID: function(o,Prefix) {
      var value = o.id;
      var TAApproverID = $get(Prefix + 'TAApproverID');
      if(TAApproverID.value==''){
        if(this.validated_FK_ATN_ApproverChangeRequest_TAApproverID_main){
          var o_d = $get(Prefix + 'TAApproverID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TAApproverID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ATN_ApproverChangeRequest_TAApproverID(value, this.validated_FK_ATN_ApproverChangeRequest_TAApproverID);
      },
    validated_FK_ATN_ApproverChangeRequest_TAApproverID_main: false,
    validated_FK_ATN_ApproverChangeRequest_TAApproverID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_atnApproverChangeRequest.validated_FK_ATN_ApproverChangeRequest_TAApproverID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_ATN_ApproverChangeRequest_TASA: function(o,Prefix) {
      var value = o.id;
      var TASA = $get(Prefix + 'TASA');
      if(TASA.value==''){
        if(this.validated_FK_ATN_ApproverChangeRequest_TASA_main){
          var o_d = $get(Prefix + 'TASA' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TASA.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ATN_ApproverChangeRequest_TASA(value, this.validated_FK_ATN_ApproverChangeRequest_TASA);
      },
    validated_FK_ATN_ApproverChangeRequest_TASA_main: false,
    validated_FK_ATN_ApproverChangeRequest_TASA: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_atnApproverChangeRequest.validated_FK_ATN_ApproverChangeRequest_TASA_main){
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
