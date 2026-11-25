import { useState } from 'react';
import {
  CssBaseline,
  ThemeProvider,
  createTheme,
  AppBar,
  Toolbar,
  Typography,
  Tabs,
  Tab,
  Box,
} from '@mui/material';
import SchoolIcon from '@mui/icons-material/School';
import ClassPage from './components/class/ClassPage';
import StudentPage from './components/student/StudentsPage';
import DiscontinuityPage from './components/discontinuity/DiscontinuityPage';
import LessonPage from './components/lesson/LessonPage';
import TeacherPage from './components/teacher/TeacherPage';

// ============================================================================
// 🧠 DÜZELTME & AÇIKLAMA: Çoklu Sayfa Yönetimi (Tabs)
// ============================================================================
// Sınıflar, Öğrenciler, Devamsızlık ve Dersler sayfaları eklendi.
// ============================================================================

const theme = createTheme({
  palette: {
    primary: { main: '#1976d2' },
  },
  typography: {
    fontFamily: '"Roboto", "Helvetica", "Arial", sans-serif',
  },
});

function App() {
  const [currentTab, setCurrentTab] = useState<number>(0);

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />

      {/* Üst Navigasyon Çubuğu */}
      <AppBar position="static">
        <Toolbar>
          <SchoolIcon sx={{ mr: 2 }} />
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Okul Yönetim Portalı
          </Typography>
          <Tabs
            value={currentTab}
            onChange={(_, newValue: number) => setCurrentTab(newValue)}
            textColor="inherit"
            indicatorColor="secondary"
          >
            <Tab label="Sınıflar" />
            <Tab label="Öğrenciler" />
            <Tab label="Devamsızlık" />
            <Tab label="Dersler" />
            <Tab label="Öğretmenler" />
          </Tabs>
        </Toolbar>
      </AppBar>

      {/* Aktif Sayfa Gösterimi */}
      <Box sx={{ mt: 2 }}>
        {currentTab === 0 && <ClassPage />}
        {currentTab === 1 && <StudentPage />}
        {currentTab === 2 && <DiscontinuityPage />}
        {currentTab === 3 && <LessonPage />}
        {currentTab === 4 && <TeacherPage />}
      </Box>
    </ThemeProvider>
  );
}

export default App;
