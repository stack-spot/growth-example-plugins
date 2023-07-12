The Plugin generates a project with the following structure:
```
    ├── build.gradle or pom.xml
    ├── docker-compose.yaml
    ├── docker_entrypoint
    ├── Dockerfile
    └── src
    └── main
    ├── java
    │ └── br
    │     └── com
    │         └── org
    │             └── projectname
    │                 └── StackApplication.java
    └── resources
    ├── application-dev.yaml
    ├── application-hom.yaml
    ├── application-prod.yaml
    └── application.yaml
```

- _build.gradle or pom.xml_: Builds tool file management with the initial Spring Boot dependencies.
- _docker-compose.yaml, Dockerfile and docker_entrypoint_: It configures the application to run in a Docker container.
- _StackApplication.java_: Spring Boot startup application class.
- _application files:_
    - _application.yaml_: It creates the configuration properties of the spring application (It's used as a global configuration).
    - _application-dev.yaml_: Sets up development environment configurations.
    - _application-hom.yaml_: Sets up staging environment configurations.
    - _application-prod.yaml_: Sets up production environment configurations.

### See the code snippet and files the Plugin adds to your project according to the informed inputs:
 
> All the variables between the **{{}}** expressions will be replaced with the informed values via input.

---

- ### Build File
    - **build.gradle**
      ```gradle
        dependencies {
            implementation 'org.springframework.boot:spring-boot-starter-validation'
            implementation 'org.springframework.boot:spring-boot-starter-web'
            developmentOnly 'org.springframework.boot:spring-boot-devtools'
            annotationProcessor 'org.springframework.boot:spring-boot-configuration-processor'
            testImplementation 'org.springframework.boot:spring-boot-starter-test'
        }
      ```   
      
    - **pom.xml**
      ```xml
        <dependencies>
            <dependency>
                <groupId>org.springframework.boot</groupId>
                <artifactId>spring-boot-starter-web</artifactId>
            </dependency>
            <dependency>
                <groupId>org.springframework.boot</groupId>
                <artifactId>spring-boot-starter-validation</artifactId>
            </dependency>
            <dependency>
                <groupId>org.springframework.boot</groupId>
                <artifactId>spring-boot-devtools</artifactId>
            </dependency>
            <dependency>
                <groupId>org.springframework.boot</groupId>
                <artifactId>spring-boot-configuration-processor</artifactId>
            </dependency>
            <dependency>
                <groupId>org.springframework.boot</groupId>
                <artifactId>spring-boot-starter-test</artifactId>
                <scope>test</scope>
            </dependency>
        </dependencies>
       ```     
              
- ### Docker      
  - **docker-compose.yaml**
    ```bash
       version: '3.9'
       services:
         "{{project_artifact_id}}":
           image: {{project_artifact_id}}
           container_name: {{project_artifact_id}}
           restart: always
           environment:
             SPRING_PROFILES_ACTIVE: default
           ports:
             - ${APP_INGRESS_SERVER_PORT:-8080}:8080
           build: .
           healthcheck:
             test: curl http://localhost:8080
             interval: 5s
             retries: 10
             start_period: 5s
             timeout: 10s
           networks:
             - app-{{project_artifact_id}}
       networks:
         app-{{project_artifact_id}}:
           driver: bridge
       ```

  - **Dockerfile**
    ```bash
      #OFFICIAL docker-hub image eclipse-temuriun for Java {{project_java_version}}
      FROM eclipse-temurin:{{project_java_version}}
      
      RUN apt-get update && apt-get -y install curl
      RUN mkdir app
      
      {%set jar_path = "build/libs" if build_tool == "Gradle" else "target" %}
      ADD {{jar_path}}/{{project_artifact_id}}-*-final.jar ./app/springApp.jar
      ADD docker_entrypoint .
      
      ENTRYPOINT ["/bin/sh", "docker_entrypoint"]
    ```      
    
  - **docker_entrypoint.sh**
    ```bash
      #!/bin/bash
      echo "Entrypoint"
      
      echo "Executing application"
      java -Djava.security.egd=file:/dev/./urandom -jar ./app/springApp.jar
    ```               

- ### Java class
  - **StackApplication.java**
    ```java
      @SpringBootApplication
      public class StackApplication {
      
      	public static void main(String[] args) {
      		SpringApplication.run(StackApplication.class, args);
      	}
      }
    ```   

- ### Properties Configuration
  - **application.yaml**
    ```yaml
      ##Default profile
      spring:
        application:
          name: meuapp
      server:
        port: 8080
    ```
    
  - **application-dev.yaml**
    ```yaml
       ##Dev profile
       spring:
        profiles: dev
    ```

  - **application-hom.yaml**
    ```yaml
       #Stage profile
       spring:
        profiles: dev
    ```
    
    - **application-prod.yaml**
    ```yaml
       #Production profile
       spring:
        profiles: prod
    ```