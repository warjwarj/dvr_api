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
                sh '''#!/bin/bash
                ./jenkins_test.bash
                '''
            }
        }
        stage('Deploy') {
            steps {
                sh 'ls -la'
                sh '''#!/bin/bash
                cd dvr_api
                dotnet publish
                chmod +x bin/Debug/net7.0/publish/dvr_api.exe
                ./dvr_api.exe
                '''
            }
        }
    }
}
