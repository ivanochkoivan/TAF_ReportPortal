pipeline {
    agent any

    options {
        skipDefaultCheckout true
        disableConcurrentBuilds()
        timestamps()
    }

    triggers {
        cron('H H * * *') // Build periodically
        pollSCM('H/2 * * * *') // Poll SCM
    }

    environment {
        DOTNET_ROOT = tool name: 'Net8_0'
        DOTNET_SDK = "$DOTNET_ROOT"
    }

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/ivanochkoivan/TAF_ReportPortal.git', branch: 'feature/module9'
            }
        }
        
        stage('Clean') {
            steps {
                script {
                    def workDir = 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal'
                    bat "${DOTNET_SDK}\\dotnet clean ${workDir} -c Debug"
                }
            }
        }

        stage('Build') {
            steps {
                script {
                    def workDir = 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal'
                    bat "${DOTNET_SDK}\\dotnet build ${workDir} -c Debug"
                }
            }
        }

        stage('Test') {
            steps {
                script {
                    def workDir = 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal'
                    bat "${DOTNET_SDK}\\dotnet test ${workDir} -c Debug"
                }
            }
        }
    }

    post {
        always {
            script {
                allure([
                    [path: '**/Tests/bin/Debug/net8.0/allure-results'],
                    [path: '**/APITests/bin/Debug/net8.0/allure-results'],
                    [path: '**/BddTest/bin/Debug/net8.0/allure-results'],
                    [path: '**/Tests.MsTests/bin/Debug/net8.0/allure-results'],
                    [path: '**/UiTestsWithAdvancedFeatures/bin/Debug/net8.0/allure-results']
                ])
            }
        }
    }
}