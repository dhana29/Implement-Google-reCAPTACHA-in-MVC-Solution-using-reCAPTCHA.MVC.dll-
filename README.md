# Implement-Google-reCAPTACHA-in-MVC-Solution-using-reCAPTCHA.MVC.dll-
Implement Google reCAPTACHA in MVC Solution using reCAPTCHA.MVC.dll 

<b>Steps:</b>
- Generate key from the below path https://www.google.com/recaptcha/admin
- Create ASP .Net MVC Template solution
- Add reCAPTCHA.MVC.dll nuget package
- Add View, Controller and Model code from the attachment
- Add below script into your html head tag
```<script src="https://www.google.com/recaptcha/api.js"></script> ```
Important to add below lines in the web.config file
 ``` 
 <appSettings>
     <add key="UnobtrusiveJavaScriptEnabled" value="true" />
     <add key="reCaptchaPublicKey" value="CopyPublicKeyFromGoogleCAPTACHA" />
     <add key="reCaptchaPrivateKey" value="CopyPrivateKeyFromGoogleCAPTACHA" />
 </appSettings>
 
 <handlers>
   <add name="MSCaptcha" verb="GET" path="CaptchaImage.axd" type="MSCaptcha.CaptchaImageHandler, MSCaptcha"/>
 </handlers>
 ```
HAPPY CODING!
