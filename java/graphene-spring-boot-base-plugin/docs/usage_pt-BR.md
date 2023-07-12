**Passo 1.** Navegue para a pasta que você vai criar seu projeto Spring Boot.

**Passo 2.** Execute o comando abaixo:
Se o Plugin estiver em uma Stack atrelada a um Workspace, execute o comando abaixo:
> Segue um exemplo. Substitua o conteúdo entre <> conforme as informações do Estúdio.
   ```bash
      stk create app myapp --starter <studio-name>/<stack-name>/<starter-name>
   ```

Se o Pugin não está associado a um Workspace e você estiver realizando testes remotos; execute o comando abaixo:
>  Abaixo é um exemplo. Substitua o conteúdo entre <> conforme as informações da Account e Studio.
   ```bash
      stk create app myapp --starter <account-name>/<studio-name>/<stack-name>/<starter-name>
   ```

**Passo 3.** Preencha as informações requisitadas
- **Project name**
- **Spring Boot version**
- **Java version**
- **Project artifact ID** (Identificador do artefato do projeto).
- **Build Tool**
- **Project group ID** (Grupo identificador do projeto). Não informe o nome do projeto no final do group ID, porque a StackSpot já solicitou essa informação por meio do input informado anteriormente.

**Passo 4.** Construa o projeto (Build the project) de acordo com seu sistema operacional:
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
  
**Passo 5.** Execute a aplicação com o docker-compose
Você pode executar a aplicação diretamente usando o perfil padrão. Ou configurar um perfil específico através da variável de ambiente **SPRING_PROFILES_ACTIVE**.

##### Exemplo:
Configure a variável de ambiente `SPRING_PROFILES_ACTIVE` no docker-compose para os seguintes cenários.
- Executar a aplicação utilizando o perfil padrão:
  ```yaml
      environment:
        SPRING_PROFILES_ACTIVE:
  ```
- Executar a aplicação usando um perfil específico:
  ```yaml
     environment:
       SPRING_PROFILES_ACTIVE: dev, hom or prod
  ```
- Suba o container:
  ```bash
      docker compose up --build --wait
  ``` 
- E pare o container com o comando:
  ```bash
     docker compose down
  ```

**Passo 6.** Execute a aplicação via Dockerfile
- Atribua um dos seguintes perfils (dev, hom, or prod), para a variável de ambiente **SPRING_PROFILES_ACTIVE** para executar a aplicação usando um perfil específico.
  ```bash
    export SPRING_PROFILES_ACTIVE=dev,hom,or prod
  ```
- Para executar a aplicação utilizando o perfil padrão, não é necessário configurar a variável de ambiente **SPRING_PROFILES_ACTIVE**
- Suba a aplicação utilizando o docker
  ```bash
    docker build . -t {{project_artifact_id}}:1.0.0
    docker run --name {{project_artifact_id}}-app -p 8080:8080 -d {{project_artifact_id}}:1.0.0
  ```

**Passo 7.** Execute a aplicação através do JAR
- Você pode executar a aplicação através do jar gerado através do build:
  ```bash
    java -jar build/libs/{{project_artifact_id}}-{{project_version}}-final.jar
  ```
- Para executar a aplicação com um perfil expecífico, você pode passar o seguinte parâmetro `-Dspring.profiles.active=dev,hom or prod`.
Veja um exemplo:
  ```bash
      java -jar -Dspring.profiles.active=dev,hom or prod build/libs/{{project_artifact_id}}-{{project_version}}-final.jar 
  ```  