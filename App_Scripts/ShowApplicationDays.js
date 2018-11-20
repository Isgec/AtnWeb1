function showDetails(o) {
	var context = o.alt;
	showProcessingMPV();
	Sys.Net.WebServiceProxy.invoke('../../App_Services/_atnWebServices.asmx', 'ShowAppliedDays', false, { context: context }, ShowAppliedDays, ShowError);
	return false;
}
function ShowAppliedDays(result) {
	hideProcessingMPV();
	dynamicMessage(result);
	showMessageMPV();
}
function ShowError(error) {
		hideProcessingMPV();
		dynamicMessage('<b>SERVER ERROR:</b> ' + error.get_message());
		showMessageMPV();
}

