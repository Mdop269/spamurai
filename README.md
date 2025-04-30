# EmailSender

Requirement .Net 8
visual studio 2022
# Steps

1) right click on the project in our case right click on EmailSender click on "manage user secret" 
2) there will be a file of secrets.json even if there is not you can create i dont have the idea 
3) copy and paste the below code 


{

    "Email_Configurations": [
        {
            "Email": "test@gmail.com",
            "password": "kqdv ivvx nrns qlve",
            "Host": "smtp.gmail.com",
            "Port": 587
        }

        // Add more email configurations as needed
    ]
}

4) enter the email from which you want to send the mail 
5) now for the password open chrome and click on dekstop site so you have a dekstop overview or if you 
have laptop you dont need to 
6) go to setting of the email which you want to use 
7) if the two step protection is not on then turn it on the search app password then create one give any app name then
you will get the password so copy that and paste it
8) dont change anything in host and port 
9) now you can add as many email configurations as you want but make sure you have some seconds difference or a random so gmail 
dont detect this as a spam


