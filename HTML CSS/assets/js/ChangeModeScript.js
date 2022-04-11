function ChangeMode()
{
    let bodyBackground = document.getElementById("Body").style.backgroundColor;

    if (bodyBackground === "lightgrey")
    {
        document.getElementById("Body").style.backgroundColor = "navy";
    }
    else
    {
        document.getElementById("Body").style.backgroundColor = "lightgrey";
    }
}