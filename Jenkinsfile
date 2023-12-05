pipeline {
    agent any

    environment {
        DOTNET_VERSION = '7'
        IMAGE_NAME = 'payment/api'
        CONTAINER_NAME = 'supreme_venkat'
        ASPNETCORE_ENVIRONMENT = 'Development'
        DOCKERFILE_PATH = 'PaymentMicroserviceThreeTierArchitecture/Dockerfile'
    }

    stages {
        stage('Build') {
            steps {
                script {
                    // Set up .NET SDK version
                    sh "dotnet --version" // Print .NET SDK version for debugging purposes
                    sh "dotnet build -c Release" // Build your .NET project
                }
            }
        }

        stage('Build Docker Image') {
            steps {
                script {
                    // Build Docker image
                    sh "docker build --no-cache -t ${IMAGE_NAME} -f ${DOCKERFILE_PATH} ."
                }
            }
        }

        stage('Push and Deploy') {
            steps {
                script {
                    // Stop and remove existing container (if any)
                    sh "docker stop ${CONTAINER_NAME} || true && docker rm ${CONTAINER_NAME} || true"

                    // Run a new container with the built image
                    sh "docker run -d --name ${CONTAINER_NAME} -p 5001:80 --env ASPNETCORE_ENVIRONMENT=${ASPNETCORE_ENVIRONMENT} ${IMAGE_NAME}:latest"
                }
            }
        }
    }
}
