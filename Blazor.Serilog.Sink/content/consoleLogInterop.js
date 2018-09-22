window.consoleLogFunctions = {
    log: function(message) {
        console.log(message);
        return true;
    },
    warning: function (message) {
        console.warn(message);
        return true;
    },
    error: function (message) {
        console.error(message);
        return true;
    }
};

