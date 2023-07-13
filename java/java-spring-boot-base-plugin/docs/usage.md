**Step 1.** Go to the folder you want to create the Spring Boot project.

**Step 2.** Execute the command below:
If the Plugin is within a Stack in the Workspace, execute the command below:
> This is an example. Replace the content between <> according to the Studio information:
   ```bash
      stk create app myapp --starter <studio-name>/<stack-name>/<starter-name>
   ```

If the Plugin isn't in a Workspace, and you're doing remote tests, execute the command below:
> This is an example. Replace the content between <> according to your Account and Studio information.
   ```bash
      stk create app myapp --starter <account-name>/<studio-name>/<stack-name>/<starter-name>
   ```

**Step 3.** Add the information
- **Project name**
- **Spring Boot version**
- **Java version**
- **Project artifact ID**
- **Build Tool**
- **Project group ID.**  Don't add the project's name at the end of the group ID. StackSpot already requested this information via the input you informed.

**Step 4.** Build the project according to your OS:
- Linux
  ```bash
  #Maven:
    ./mvnw clean install
  #OR Gradle
    ./gradlew build
  ```
- Windows
  ```bash
  #Maven: 
      mvnw clean install
  #OR Gradle: 
      gradlew build
  ```
**Step 5.** Run the application via docker-compose:
You can directly run docker-compose using the default profile. Or configure a specific profile through **SPRING_PROFILES_ACTIVE** environment variable.

##### E.g:
Configure the environment variable `SPRING_PROFILES_ACTIVE` on docker-compose file to the following scenarios:
- Run the application using the default profile:
  ```yaml
    environment:
      SPRING_PROFILES_ACTIVE:
  ```
- Run the application using a specific profile:
  ```yaml
    environment:
      SPRING_PROFILES_ACTIVE: dev, hom or prod
  ```
- Run the command below to put the container up:
  ```bash
      docker compose up --build --wait
  ``` 
- Put container down:
  ```bash
     docker compose down
  ```

**Step 6.** Run the application via Dockerfile
- Set up one of the profiles (dev, hom, or prod) to the environment variable **SPRING_PROFILES_ACTIVE** to run the application using a specific profile.
  ```bash
    export SPRING_PROFILES_ACTIVE=dev,hom,or prod
  ```
- To run the application using the default profile, it's not necessary to set up the environment variable **SPRING_PROFILES_ACTIVE**:
- Put the container up using docker
  ```bash
    docker build . -t {{project_artifact_id}}:1.0.0
    docker run --name {{project_artifact_id}}-app -p 8080:8080 -d {{project_artifact_id}}:1.0.0
  ```
  
**Step 7.** Run the application through the JAR
- After building, you can run the application jar through the following command:
  ```bash
    java -jar build/libs/{{project_artifact_id}}-{{project_version}}-final.jar
  ```
- You can run a specific profile through the following parameter `-Dspring.profiles.active=dev,hom or prod`
See the example:
  ```bash
      java -jar -Dspring.profiles.active=dev,hom or prod build/libs/{{project_artifact_id}}-{{project_version}}-final.jar 
  ```  