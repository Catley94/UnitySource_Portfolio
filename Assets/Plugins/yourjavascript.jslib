mergeInto(LibraryManager.library, {
	
	SetLocation: function (location) {
	    setLocation(UTF8ToString(location));
	},
	
	SetWeatherAPIKey: function (key) {
    	setWeatherAPIKey(UTF8ToString(key));
    },
    
    CopyToClipboard: function(text) {
        navigator.clipboard.writeText(UTF8ToString(text));
    },

});