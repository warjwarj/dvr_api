pipeline {
    agent {
        label 'docker-ssh-agent'
    }
    options {
        skipDefaultCheckout(true)
    }
    stages {
        stage('Setup') {
            steps {
                checkout scm
                sh 'source /etc/.bashrc'
                // Verify the environment variables are set
                sh 'env'
            }
        }
        stage('Test') {
            steps {
                // Print the current directory and list files to ensure the script is present
                sh 'pwd'
                sh 'ls -la'
                
                // Check if the file exists and is executable
                sh 'if [ -x jenkins_test.bash ]; then echo "File is executable"; else echo "File is not executable"; fi'
                
                // Execute the script with explicit path and check for errors
                sh '''#!/bin/bash
                set -e
                dotnet --version
                chmod +x jenkins_test.bash
                ./jenkins_test.bash
                '''
            }
        }
    }
}
