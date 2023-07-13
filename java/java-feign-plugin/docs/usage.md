It's possible to apply this plugin in the app-type application. Run the STK CLI command to add the plugin to your application:
If the Plugin is within a Stack in the Workspace, execute the command below:
> This is an example. Replace the content between <> according to the Studio information:
   ```bash
      stk apply plugin <studio-name>/<stack-name>/feign-plugin
   ```

If the Plugin isn't in a Workspace, and you're doing remote tests, execute the command below:
> This is an example. Replace the content between <> according to your Account and Studio information.
   ```bash
      stk apply plugin <account-name>/<studio-name>/<stack-name>/feign-plugin
   ```
