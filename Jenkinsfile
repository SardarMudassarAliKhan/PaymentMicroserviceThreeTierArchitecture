pipeline {
    agent any
     tools { 
       
        
    }    
    stages {
        
       
        stage('Build') {
            steps {
                 sh 'docker build --no-cache -t payment/api -f PaymentMicroserviceThreeTierArchitecture/Dockerfile .'

            }
        }
        stage('Push and Deploy') {
            steps {                
                sh 'docker stop supreme_venkat || true && docker rm supreme_venkat || true'
                sh 'docker run -d --name supreme_venkat -p 5001:80 --env "ASPNETCORE_ENVIRONMENT=Development" payment/api:latest'
            }
        }
    }
}
