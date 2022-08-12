def makeBuild = {
  bat "nuget restore Kartverket.ShapeChange.EA.Addin.sln"
  changeAsmVer versionPattern: "${VERSION_NUMBER}"
  // TODO: Run Wix ...
  archiveArtifacts artifacts: "${ARTIFACTFILE_FULLNAME}"
  bat "copy ${ARTIFACTFILE_FULLNAME} ${INSTALLFILE_FULLNAME}"    
}

pipeline {
  agent any
  environment {
    PACKAGE_NAME = "ShapeChange-EA-Addin"
    PROJECT_PRIMARY = "Kartverket.ShapeChange.EA.Addin"
    ARTIFACTFILE_FULLNAME = "path\\to\\artifact\\file"
    INSTALLFILE_BASEDIRECTORY = "C:\\inetpub\\sites\\download\\shapechange-ea-addin\\"
  }
  stages {
    stage("MakeReleaseCandidate") {
      when {
        branch "release/*"
      }
      environment {
        VERSION_NUMBER = "0.0.0.${currentBuild.getNumber()}"      
        RC_VERSION = BRANCH_NAME.minus("release/")
        RC_NUMBER = currentBuild.getNumber()
        INSTALLFILE_FILENAME = "NORELEASE_${PACKAGE_NAME}-${RC_VERSION}_RC${RC_NUMBER}.exe"
        INSTALLFILE_FULLNAME = "${INSTALLFILE_BASEDIRECTORY}release-candidates\\${INSTALLFILE_FILENAME}"
      }
      steps {
        script {makeBuild()}
      }
    }
    stage("MakeRelease") {
      when {
        buildingTag()
      }
      environment {
        VERSION_NUMBER = "${TAG_NAME}"
        INSTALLFILE_FILENAME = "${PACKAGE_NAME}-${TAG_NAME}.exe"
        INSTALLFILE_FULLNAME = "${INSTALLFILE_BASEDIRECTORY}releases\\${INSTALLFILE_FILENAME}"
      }
      steps {
        script {makeBuild()}
      }
    }
  }
}

// Required Jenkins config
//
// Jenkins Git plugin: Discover branches, Discover tags
// SCM API Plugin - Filter by name (with regular expression): release\/\d+\.\d+\.\d+|\d+\.\d+\.\d+
// Basic Branch Build Strategies Plugin: Regular branches, Tags
//
// The name filter regex ensures that RC_VERSION (in stage MakeReleaseCandidate) or TAG_NAME (in stage MakeRelease)
// has a (3-part) version number format, e.g. 1.0.0 from a branch named release/1.0.0 or a tag named 1.0.0
