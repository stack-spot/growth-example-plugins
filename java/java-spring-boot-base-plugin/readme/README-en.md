## Web API com Spring Boot

This template accelerates the development and the Web APIs for Cloud Native environments publication with Spring Boot, and other Spring technologies.

### **Requirements**
- [**docker >= 20.10.12**](https://docs.docker.com/engine/install/)
- [**docker compose >= v2.11.2**](https://docs.docker.com/compose/install/)

##### Get started
- Build the application using **gradle** or **maven**.  See an example below:
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
            mvnw clean install**
        #OR Gradle: 
            gradlew build
        ``` 

##### 1. Run the application via docker-compose
You can directly run docker-compose using the default profile. Or configure a specific profile through **SPRING_PROFILES_ACTIVE** environment variable.

See an example: 
    - To run the default profile it's necessary to configure docker-compose, see below:
        ```yaml
            environment:
              SPRING_PROFILES_ACTIVE:
        ```
    - To run a specific profile, configure docker-compose, see below:
       ```yaml
           environment:
             SPRING_PROFILES_ACTIVE: dev, hom or prod
       ```
- Put container up:
    ```bash
        docker-compose up --build
    ``` 
- Put container down:
    ```bash
       docker-compose down
    ```

##### 2. Execute the application via Dockerfile
 To run a specific profile:
    - Export the **SPRING_PROFILES_ACTIVE** environment variable. 
    - Set one of the profiles (dev, homologation, or prod), or you can execute using the default profile:
    
         ```bash
            docker build . -t {{project_artifact_id}}:1.0.0
            docker run --name {{project_artifact_id}}-app -p 8080:8080 -d {{project_artifact_id}}:1.0.0
        ```


#### 4. Execute the application directly
After building, you can execute the application jar through the following command:
    ```
        java -jar build/libs/{{project_artifact_id}}-{{project_version}}-final.jar 
    ```
- You can run a specific profile setting with the following configuration:
    - -Dspring.profiles.active=dev,hom or prod

- ### See the example:
    ```
        java -jar -Dspring.profiles.active=dev,hom or prod build/libs/{{project_artifact_id}}-{{project_version}}-final.jar 
    ```
