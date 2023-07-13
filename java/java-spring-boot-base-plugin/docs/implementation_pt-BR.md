Este Plugin gera um projeto com a seguinte estrutura:
```
    ├── build.gradle or pom.xml
    ├── docker-compose.yaml
    ├── Dockerfile
    ├── docker_entrypoint
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

- _build.gradle or pom.xml_: Arquivo de construção contendo as dependencias iniciais do Spring Boot.
- _docker-compose.yaml, Dockerfile and docker_entrypoint_: Configura a aplicação para ser executada em um container Docker.
- _StackApplication.java_: Classe de inicialização do contexto do Spring Boot.
- _application files:_
  - _application.yaml_: Responsável por criar as configurações de propriedades da aplicação Spring Boot (Usado como configuração global).
  - _application-dev.yaml_: Define as configurações relacionadas ao ambiente de desenvolvimento.
  - _application-hom.yaml_: Define as configurações relacionadas ao ambiente de homologação.
  - _application-dev.yaml_: Define as configurações relacionadas ao ambiente de produção.

### Confira abaixo os trechos de código e/ou arquivos que são adicionados no seu projeto conforme os inputs informados anteriormente:

> Todas as variáveis das entre as expressões **{{}}** serão substituídas pelos valores informados via input. 

---

- ### Arquivo de build (Build Tool)
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
      
- ### Propriedades de configuração
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