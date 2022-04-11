function IsInputEmpty()
{
    if (document.getElementById("FirstName").value === ""
        || document.getElementById("LastName").value == ""
        || document.getElementById("Email").value == ""
        || document.getElementById("Username").value == ""
        || document.getElementById("Password").value == ""
        || document.getElementById("ConfirmPassword").value == "")
    {
        return true;
    }
    else
        return false;
}

var users = [];

function Registrate()
{
    if (IsInputEmpty())
    {
        window.alert("Fill all the required fields.");
        return;
    }

    const User = 
    {
    FirstName : document.getElementById("FirstName").value,
    LastName : document.getElementById("LastName").value,
    Email : document.getElementById("Email").value,
    Username : document.getElementById("Username").value,
    Password : document.getElementById("Password").value
    }

    users.push(User);

    if (User.Password !== document.getElementById("ConfirmPassword").value)
    {
        window.alert("Passwords are not matching! Try again.");
    }
    else
    {
        window.alert("Registration successfull!");
    }
}

function ShowUser()
{
    for (let i = 0; i < users.length; i++)
    {
        document.getElementById("UsersDisplay").innerHTML += users[i].FirstName + " " + users[i].LastName + "<br>";
    }
}

