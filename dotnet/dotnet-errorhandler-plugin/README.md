## **About**
The **dotnet-errorhandler-plugin** adds to the Stack the ability to standardize error returns from REST applications.


#### **Prerequisites**
The items you need to install to use the Plugin:

- .NET 6;   
- The **`dotnet-api-plugin`** template.


### **Usage**
### **Automatic Settings**

Add it to your `IApplicationBuilder`, in `Program.cs`, the code below.

```csharp
app.UseErrorHandler();
```

#### **Handled Exceptions**

- Using the  `HttpResponseException` class, you can customize the message and define a `HttpStatusCode`. To standardize the API return, it is possible to write the error log occurring through the `logActive` property. If the value is equal to `false`, the log is not written.
- The `HttpResponseException` class has several overloads in its constructor, it's possible to assign value in the properties below:


| **Property** | **Description** |
| :--- | :--- |
| `logActive` | Property that allows enabling log recording |
| `statusCode` | `HttpStatusCode` that will be returned in the request |
| `logLevel` | Log level to be written |
| `message` | Message to be returned in the request |
| `exception` | Exception to be written |

### **Examples of plugin usage**

500 - Internal Server Error

```csharp
throw new HttpResponseException("An error occurred while trying to save the record", true);
```

Resultado:
```json
{
  "error_id": "62ec9afe-64ad-46cb-8df0-abfd306cb7dc",
  "message": "An error occurred while trying to save the record"
}
```

400 - Bad Request - In this case, logging has not been enabled.


```csharp
throw new HttpResponseException(HttpStatusCode.BadRequest, "Field Name is required", false);
```

Result:
```json
{
  "error_id": "62ec9afe-64ad-46cb-8df0-abfd306cb7dc",
  "message": "Field Name is required"
}
```

400 - Bad Request

```csharp
throw new HttpResponseException(HttpStatusCode.BadRequest, "Field Name is required", true);
```

Result:
```json
{
  "error_id": "62ec9afe-64ad-46cb-8df0-abfd306cb7dc",
  "message": "Field Name is required"
}
```

- Using the `HttpResponseObjectException` class - this has similar behavior to `HttpResponseException`, with the same overloads mentioned before. But in this case it is also possible to receive a `HttpRequestMessage` and `HttpResponseMessage` as parameters.



#### **Unhandled Exceptions**

Whenever an unhandled exception occurs it is suppressed and the log is always logged. The `HttpStatusCode` will be `500 - Internal Server Error` and the API will return something like the example below:


```json
{
  "error_id": "62ec9afe-64ad-46cb-8df0-abfd306cb7dc",
  "message": "An unexpected system error has occurred"
}
```
