pipeline {
    agent any

    environment {
        IMAGE_NAME = 'dvr_api:latest'
        CONTAINER_NAME = 'dvr_api-container'
        CONTAINER_PORTS = '9046-9048:9046-9048'
    }

    stages {
        stage('Checkout') {
            steps {
                // Checkout into /var/jenkins_home/workspace/
                checkout scm
            }
        }
        stage('Test') {
            steps {
                script {
                    // Test the .NET application inside a Docker container
                    docker.image('mcr.microsoft.com/dotnet/sdk:5.0').inside {
                        bash 'dvr_api/jenkinsTestScript.bash'
                    }
                }
            }
        }

        stage('Publish') {
            steps {
                script {
                    // Build the the final image, using dotnet publish 
                    sh "docker build -t ${IMAGE_NAME} dvr_api/dvr_api/"
                }
            }
        }

        stage('Deploy') {
            steps {
                script {
                    // Deploy the Docker container
                     sh "docker stop ${CONTAINER_NAME} || true"
                     sh "docker rm ${CONTAINER_NAME} || true"
                     sh "docker run -d --name ${CONTAINER_NAME} -p ${CONTAINER_PORTS} ${IMAGE_NAME}"
                }
            }
        }
    }

    post {
        always {
            // Clean up Docker containers
            script {
                sh 'docker system prune -f'
            }
        }
        success {
            echo 'Pipeline completed successfully!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}
