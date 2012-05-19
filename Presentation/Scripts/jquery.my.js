
    function onAddTag(tag) {
			alert("Added a tag: " + tag);
		}
		function onRemoveTag(tag) {
			alert("Removed a tag: " + tag);
		}
		
		function onChangeTag(input,tag) {
			alert("Changed a tag: " + tag);
		}
    $(function () {
        $('#tags').tagsInput({
            autocomplete_url: "http://localhost:6229/temp.html",
            autocomplete: { selectFirst: true, width: '100px', autoFill: true }
        });
		$('input.tags').tagsInput({onAddTag:onAddTag,onRemoveTag:onRemoveTag,onChange: onChangeTag});
});