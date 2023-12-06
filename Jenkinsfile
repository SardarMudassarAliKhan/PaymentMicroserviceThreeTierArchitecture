pipeline {
    agent any

   

    stages {
        stage('Build') {
            steps {
                script {
                    // Build Docker image
                    sh 'docker build --no-cache -t payment/api -f PaymentMicroserviceThreeTierArchitecture/Dockerfile .'
                }
            }
        }

        stage('Push and Deploy') {
            steps {
                script {
                    // Stop and remove existing container (if any)
                    sh 'docker stop supreme_venkat || true && docker rm supreme_venkat || true'

                    // Run a new container with the built image
                    sh 'docker run -d --name supreme_venkat -p 5002:80 --env "ASPNETCORE_ENVIRONMENT=Development" payment/api:latest'
                }
            }
        }
    }
}
