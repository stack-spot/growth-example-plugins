package {{global_computed_inputs.base_package}}.config;
import org.springframework.context.annotation.Configuration;
import org.springframework.cloud.openfeign.EnableFeignClients;

@Configuration
@EnableFeignClients("{{global_computed_inputs.base_package}}.*")
public class FeignConfig {

}