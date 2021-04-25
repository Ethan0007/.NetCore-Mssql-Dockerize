# .NetCore Mssql Dockerize Playground

This repository is just a playground for containerizing .net core and mssql at the same time.

## Requirements   
 * .NET Core 3.1  
 * VSCode  
 * Docker  20.10.0
 
## Running the application:  
1. Run Docker on your local machine.
2. docker build -t sample-api:v1 . 
   - it will download images for aspnet 3.1 and sdk 3.1 (wait until the download done).
3. docker-compose up -d
4. to verify the image enter command:  docker images


 ## License 
  [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)  
  Copyright (c) 2021 [Joever Monceda](https://github.com/Ethan0007)


  Linkedin: [Joever Monceda](https://www.linkedin.com/in/joever-monceda-55242779/)  
  Medium: [Joever Monceda](https://medium.com/@joever.monceda/new-net-core-vuejs-vuex-router-webpack-starter-kit-e94b6fdb7481)  
  Twitter [@_EthanHunt07](https://twitter.com/_EthanHunt07)  
  Facebook: [JH Hunt](https://www.facebook.com/nethan.hound.3)
