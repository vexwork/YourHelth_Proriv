$(document).ready(function(){

    const apiUrl = 'http://192.168.8.169/api/v1';

    console.log(localStorage.getItem('user-id'));

    if(localStorage.getItem('user-id')!=null)
    {
        window.location.href = "/list.html";
    }
    else
    {
        //window.location.href = "/";
    }

    $("input").on("keyup",function(){

       if($(this).val()!='') $(this).removeClass("error");

    });
    var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);

    $("#registerAction").click(function(){
        var error = false;
        $("#registerForm input").each(function(){
            if($(this).val()=='')
            {
                $(this).addClass("error");
                error = true;
            }
        });
        //
        // if( !pattern.test($("#registerForm [name='email']").val()) ) {
        //     $("#registerForm [name='email']").addClass("error");
        //     error = true;
        // }

        if(error === false)
        {
            let name = $("#registerForm input[name='fullanme']").val().split(' ');
            if(!name[1]) name[1]= '-';
            if(!name[2]) name[2]= '-';
            //$("#registerForm input[name='dateBirth']").val()
            let formDataArray = JSON.stringify({
                "personalId": $("#registerForm input[name='snils']").val(),
                "firstName": name[1],
                "lastName" : name[0],
                "middleName": name[2],
                "birthDate": new Date().toISOString(),
            });

            $.ajax({
                type: "POST",
                url: apiUrl+'/register-patient/',
                dataType: 'application/json',
                data: formDataArray,
                cache:false,
                beforeSend: function(){
                  console.log(formDataArray);
                },
                success: function (answer) {
                    if(answer.guid==null)
                    {
                        alert(answer.message);
                    }
                    else
                    {
                        localStorage.setItem('user-id',answer.guid);
                        window.location.href = "/list";
                    }
                }
            });

            window.location.href = "/list.html";
        }

        return false;
        /*



        {
          "personalId": "string",
          "firstName": "string",
          "lastName": "string",
          "middleName": "string",
          "birthDate": "2019-06-09T10:00:05.787Z"
        }



         */

        //return false;
    });


    $(".tasks__one").click(function(){
        $(".popup").fadeIn(500);
    });


    $(".popup .btn-green").click(function(){
        $(".popup").fadeOut(500);
        setTimeout(function(){
            $("#task1").slideUp(500);
        },500);

    });

});