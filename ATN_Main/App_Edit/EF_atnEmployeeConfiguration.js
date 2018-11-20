<script type="text/javascript"> 
var script_atnEmployeeConfiguration = {
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
    temp: function() {
    }
    }
</script>
