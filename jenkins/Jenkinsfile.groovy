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
        DOTNET_SDK = "\"${DOTNET_ROOT}\\dotnet\""
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
                    def workDir = 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal_Pipeline'
                    bat "${DOTNET_SDK} clean ${workDir} -c Debug"
                }
            }
        }

        stage('Build') {
            steps {
                script {
                    def workDir = 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal_Pipeline'
                    bat "${DOTNET_SDK} build ${workDir} -c Debug"
                }
            }
        }

        stage('Test') {
            steps {
                script {
                    def workDir = 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal_Pipeline'
                    bat "${DOTNET_SDK} test ${workDir} -c Debug"
                }
            }
        }
    }

    post {
		always {
			script {
				allure([
					[path: 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal_Pipeline\\Tests\\bin\\Debug\\net8.0\\allure-results'],
					[path: 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal_Pipeline\\APITests\\bin\\Debug\\net8.0\\allure-results'],
					[path: 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal_Pipeline\\BddTest\\bin\\Debug\\net8.0\\allure-results'],
					[path: 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal_Pipeline\\Tests.MsTests\\bin\\Debug\\net8.0\\allure-results'],
					[path: 'C:\\Users\\Ivan\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\TAF_ReportPortal_Pipeline\\UiTestsWithAdvancedFeatures\\bin\\Debug\\net8.0\\allure-results']
				])
			}
		}
	}
	
}