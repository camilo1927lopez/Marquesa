function timerInactivo(dotnetHelper){
    var timer;
    /*document.onmousemove = resetTimer;*/
    document.onclick = resetTimer;
    //document.onkeypress = resetTimer;

    function resetTimer() {

        clearTimeout(timer);
        timer = setTimeout(logout, 600000);

        var id = window.setTimeout(function () { }, 0);

        while (id--) {
            window.clearTimeout(id); // will do nothing if no timeout with id is present
        }
        timer = setTimeout(logout, 600000);

    }

    function logout() {
        dotnetHelper.invokeMethodAsync("Logout");
    }

}