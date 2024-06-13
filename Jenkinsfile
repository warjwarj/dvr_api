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
                sh 'chmod +x jenkins_test.bash'
            }
        }
        stage('Test') {
            steps {
                sh 'ls -la'
                sh 'echo $SHELL'
                sh '''#!/bin/bash
                set -e
                dotnet --version
                ./jenkins_test.bash
                '''
            }
        }
    }
}
