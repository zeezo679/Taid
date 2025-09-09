// Enhanced site-wide JavaScript functionality - Dark Theme

document.addEventListener('DOMContentLoaded', function() {
    // Force dark theme application
    applyDarkTheme();
    
    // Initialize all enhanced features
    initializeTooltips();
    initializeAnimations();
    initializeInteractiveElements();
    initializeFormEnhancements();
});

// Force Dark Theme Application
function applyDarkTheme() {
    // Set CSS custom properties
    const root = document.documentElement;
    root.style.setProperty('--bs-body-bg', '#1a1a1a');
    root.style.setProperty('--bs-body-color', '#ffffff');
    root.style.setProperty('--bs-emphasis-color', '#ffffff');
    root.style.setProperty('--bs-secondary-bg', '#2d2d2d');
    root.style.setProperty('--bs-tertiary-bg', '#404040');
    
    // Force body styling
    document.body.style.backgroundColor = '#1a1a1a';
    document.body.style.color = '#ffffff';
    
    // Apply dark theme to all cards
    document.querySelectorAll('.card').forEach(card => {
        card.style.backgroundColor = '#252525';
        card.style.borderColor = '#404040';
        card.style.color = '#ffffff';
    });
    
    // Apply dark theme to form controls
    document.querySelectorAll('.form-control, .form-select').forEach(control => {
        control.style.backgroundColor = '#1e1e1e';
        control.style.borderColor = '#404040';
        control.style.color = '#ffffff';
    });
    
    // Apply dark theme to navbar
    const navbar = document.querySelector('.navbar');
    if (navbar) {
        navbar.style.backgroundColor = '#252525';
        navbar.style.borderBottomColor = '#404040';
    }
    
    // Apply dark theme to footer
    const footer = document.querySelector('footer');
    if (footer) {
        footer.style.backgroundColor = '#252525';
        footer.style.borderTopColor = '#404040';
        footer.style.color = '#b3b3b3';
    }
}

// Tooltip functionality
function initializeTooltips() {
    // Initialize Bootstrap tooltips
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
}

// Animation observers
function initializeAnimations() {
    // Intersection Observer for scroll animations
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };
    
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animate-fade-in');
                observer.unobserve(entry.target);
            }
        });
    }, observerOptions);
    
    // Observe elements that should animate on scroll
    document.querySelectorAll('.card, .table, .alert').forEach(el => {
        observer.observe(el);
    });
}

// Interactive elements
function initializeInteractiveElements() {
    // Enhanced button interactions
    document.querySelectorAll('.btn-primary, .btn-secondary, .btn-outline-primary').forEach(btn => {
        btn.addEventListener('mouseenter', function() {
            this.style.transform = 'translateY(-2px)';
            this.style.transition = 'transform 0.2s ease';
        });
        
        btn.addEventListener('mouseleave', function() {
            this.style.transform = 'translateY(0)';
        });
        
        btn.addEventListener('mousedown', function() {
            this.style.transform = 'translateY(0)';
        });
    });

    // Card hover effects
    document.querySelectorAll('.card').forEach(card => {
        card.addEventListener('mouseenter', function() {
            this.style.transform = 'translateY(-3px)';
            this.style.transition = 'transform 0.3s ease';
            this.style.borderColor = '#0ea5e9';
        });
        
        card.addEventListener('mouseleave', function() {
            this.style.transform = 'translateY(0)';
            this.style.borderColor = '#404040';
        });
    });
}

// Form enhancements
function initializeFormEnhancements() {
    // Enhanced form validation feedback
    document.querySelectorAll('form').forEach(form => {
        form.addEventListener('submit', function(e) {
            const submitBtn = this.querySelector('button[type="submit"]');
            if (submitBtn && this.checkValidity()) {
                // Show loading state
                submitBtn.innerHTML = '<span class="spinner-border spinner-border-sm me-2" role="status"></span>Loading...';
                submitBtn.disabled = true;
            }
        });
    });

    // Enhanced input focus effects
    document.querySelectorAll('.form-control, .form-select').forEach(input => {
        input.addEventListener('focus', function() {
            this.style.borderColor = '#0ea5e9';
            this.style.boxShadow = '0 0 0 0.2rem rgba(14, 165, 233, 0.25)';
            this.parentElement.classList.add('focused');
        });
        
        input.addEventListener('blur', function() {
            this.style.borderColor = '#404040';
            this.style.boxShadow = 'none';
            this.parentElement.classList.remove('focused');
        });
    });

    // Real-time validation feedback
    document.querySelectorAll('input[data-val="true"]').forEach(input => {
        input.addEventListener('blur', function() {
            validateField(this);
        });
    });
}

// Field validation helper
function validateField(field) {
    const isValid = field.checkValidity();
    
    if (!isValid) {
        field.classList.add('is-invalid');
        field.classList.remove('is-valid');
        field.style.borderColor = '#ef4444';
        field.style.boxShadow = '0 0 0 0.2rem rgba(239, 68, 68, 0.25)';
    } else {
        field.classList.add('is-valid');
        field.classList.remove('is-invalid');
        field.style.borderColor = '#10b981';
        field.style.boxShadow = '0 0 0 0.2rem rgba(16, 185, 129, 0.25)';
    }
}

// Utility functions
function showAlert(message, type = 'success') {
    const alertHtml = `
        <div class="alert alert-${type} alert-dismissible fade show" role="alert">
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        </div>
    `;
    
    // Insert at top of main content
    const mainContent = document.querySelector('main');
    if (mainContent) {
        mainContent.insertAdjacentHTML('afterbegin', alertHtml);
    }
}

// Smooth scrolling for anchor links
function initializeSmoothScroll() {
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });
}

// Auto-hide alerts
function initializeAlertAutoHide() {
    setTimeout(function() {
        const alerts = document.querySelectorAll('.alert');
        alerts.forEach(alert => {
            if (bootstrap.Alert) {
                const bsAlert = new bootstrap.Alert(alert);
                bsAlert.close();
            }
        });
    }, 5000);
}

// Initialize additional features
initializeSmoothScroll();
initializeAlertAutoHide();

// Continuously apply dark theme (in case of dynamic content)
setInterval(applyDarkTheme, 1000);

// Global utility functions
window.toggleMobileMenu = function() {
    const navbar = document.querySelector('.navbar-collapse');
    if (navbar) {
        const bsCollapse = new bootstrap.Collapse(navbar);
        bsCollapse.toggle();
    }
};

// Export utility functions for external use
window.DemoUtils = {
    showAlert: showAlert,
    validateField: validateField,
    applyDarkTheme: applyDarkTheme
};
